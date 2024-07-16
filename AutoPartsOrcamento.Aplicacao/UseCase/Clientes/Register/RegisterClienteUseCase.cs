using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;

public class RegisterClienteUseCase(AppDbContext dbContext)
{

    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseClienteJson>> Execute(CreateClienteRequest request)
    {
        
        Validate(request);    
        
        var cliente = new Cliente
        {
            Nome = request.Nome,
            Email = request.Email,
            CpfCnpj = request.CpfCnpj,
            Telefone = request.Telefone,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        await _dbContext.Clientes.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
            
        return new Response<ResponseClienteJson>()
        {
            Data = [new ResponseClienteJson
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                CpfCnpj = cliente.CpfCnpj,
                Email = cliente.Email,
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt
            }]
        };
    }
    
    private void Validate(CreateClienteRequest request)
    {
        var validator = new RegisterClienteValidator();
        var result = validator.Validate(request);

        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidateException(errorMessages);
        }
    }
}
