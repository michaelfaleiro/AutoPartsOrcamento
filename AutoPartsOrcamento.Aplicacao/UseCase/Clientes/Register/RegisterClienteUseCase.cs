using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Infra.Entities;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;

public class RegisterClienteUseCase(AppDbContext dbContext)
{

    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseClienteJson>> Execute(CreateClienteRequest request)
    {
        
        Validate(request);    
        
        var entity = new Cliente
        {
            Nome = request.Nome,
            Email = request.Email,
            CpfCnpj = request.CpfCnpj,
            Telefone = request.Telefone,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        
        await _dbContext.Clientes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
            
        return new Response<ResponseClienteJson>()
        {
            Data = [new ResponseClienteJson
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                CpfCnpj = entity.CpfCnpj,
                Email = entity.Email,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
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
