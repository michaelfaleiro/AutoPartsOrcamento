using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetAll;

public class GetAllClientesUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<PagedResponse<ResponseClienteJson>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.Clientes.AsNoTracking();
        
        var clientes = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = clientes.Count;

        return new PagedResponse<ResponseClienteJson>
        {
            Data = clientes.Select(x => new ResponseClienteJson
            {
                Id = x.Id,
                Nome = x.Nome,
                Telefone = x.Telefone,
                CpfCnpj = x.CpfCnpj,
                Email = x.Email,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList(),
            CurrentPage = 1,
            PageSize = pageSize,
            TotalCount = count
            
        };
    }

}