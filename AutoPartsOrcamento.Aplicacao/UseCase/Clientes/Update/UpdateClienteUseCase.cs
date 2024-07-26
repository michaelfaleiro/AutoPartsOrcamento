using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Update;

public class UpdateClienteUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseClienteJson>> Execute(UpdateClienteRequest request)
    {
        Validate(request);
        
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }

        cliente.Nome = request.Nome;
        cliente.CpfCnpj = request.CpfCnpj;
        cliente.Email = request.Email;
        cliente.Telefone = request.Telefone;
        cliente.UpdatedAt = DateTime.UtcNow;
        
        await _dbContext.SaveChangesAsync();

        return new Response<ResponseClienteJson>
        {
            Data = new ResponseClienteJson
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CpfCnpj = cliente.CpfCnpj,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt
            }
        };
    }

    private void Validate(UpdateClienteRequest request)
    {
        var validator = new UpdateClienteValidator();
        
        var result = validator.Validate(request);
        
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidateException(errorMessages);
        }
    }
    
}