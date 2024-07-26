using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.GetAll;

public class GetAllStatusOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<PagedResponse<ResponseStatusOrcamentoJson>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.StatusOrcamentos.AsNoTracking();
        
        var statusOrcamentos = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = await query.CountAsync();
        
        return new PagedResponse<ResponseStatusOrcamentoJson>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            Data = statusOrcamentos.Select(statusOrcamento => new ResponseStatusOrcamentoJson
            {
                Id = statusOrcamento.Id,
                Nome = statusOrcamento.Nome,
                Descricao = statusOrcamento.Descricao,
                Ativo = statusOrcamento.Ativo,
                CreatedAt = statusOrcamento.CreatedAt,
                UpdatedAt = statusOrcamento.UpdatedAt
            }).ToList()
        };
    }
    
}