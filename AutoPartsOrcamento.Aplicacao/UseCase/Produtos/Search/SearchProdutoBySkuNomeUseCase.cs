using AutoPartsOrcamento.Comunicacao.Request.Produto;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Search
{
    public class SearchProdutoBySkuNomeUseCase(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<PagedResponse<ResponseProdutoJson>> Execute(SearchProdutoRequest request)
        {

            var produtos = await _dbContext.Produtos
                .AsNoTracking()
                .Where(p => p.Sku.Contains(request.Query)
                            || p.Nome.Contains(request.Query)).ToListAsync();


            return new PagedResponse<ResponseProdutoJson>()
            {
                Data = produtos.Select(p => new ResponseProdutoJson()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Sku = p.Sku,
                    ValorVenda = p.ValorVenda,
                    Fabricante = p.Fabricante,
                    ImagemUrl = p.ImagemUrl,
                    Descricao = p.Descricao,
                    Observacao = p.Observacao,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }).ToList()
            };
        }
    }
}