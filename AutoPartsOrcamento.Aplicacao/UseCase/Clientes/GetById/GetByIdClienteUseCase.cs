using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetById;

public class GetByIdClienteUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseClienteJson>> Execute(Guid id)
    {
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

        if (cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

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
}