using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.GetAll;

public class GetAllStatusCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<PagedResponse<ResponseStatusOrcamentoJson>> Execute()
    {
        var statusCotacao = await _dbContext
            .StatusCotacoes.AsNoTracking().ToListAsync();

        return new PagedResponse<ResponseStatusOrcamentoJson>
        {
            Data = statusCotacao.Select(status => new ResponseStatusOrcamentoJson
            {
                Id = status.Id,
                Nome = status.Nome,
                Descricao = status.Descricao,
                Ativo = status.Ativo,
                CreatedAt = status.CreatedAt,
                UpdatedAt = status.UpdatedAt
            }).ToList()
        };
    }
    
}