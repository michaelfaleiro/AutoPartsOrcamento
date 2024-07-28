using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetAllSimilares;

public class GetAllCodigoSimilaresUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<PagedResponse<ResponseCodigoSimilarProdutoJson>> Execute(Guid itemId)
    {
        var similares = await _dbContext
            .CodigoSimilarProdutos
            .Include( x => x.CotacaoItem)
            .Where(x => x.CotacaoItem.Id == itemId)
            .ToListAsync();
        
        return new PagedResponse<ResponseCodigoSimilarProdutoJson>()
        {
            Data = similares.Select(x => new ResponseCodigoSimilarProdutoJson()
            {
                Id = x.Id,
                ItemId = x.CotacaoItem.Id,
                Sku = x.Sku,
                Fabricante = x.Fabricante,
                Tipo = x.Tipo
                
            }).ToList()
        };
    }
    
}