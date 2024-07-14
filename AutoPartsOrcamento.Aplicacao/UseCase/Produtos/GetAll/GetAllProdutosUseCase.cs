using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.GetAll;

public class GetAllProdutosUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<PagedResponse<ResponseProdutoJson>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.Produtos
            .Take(pageSize)
            .AsQueryable();

        var produtos = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = produtos.Count;

        return new PagedResponse<ResponseProdutoJson>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            Data = produtos.Select(produto => new ResponseProdutoJson
            {
                Id = produto.Id,
                Sku = produto.Sku,
                Nome = produto.Nome,
                Fabricante = produto.Fabricante,
                Descricao = produto.Descricao,
                ValorCusto = produto.ValorCusto,
                ValorVenda = produto.ValorVenda,
                ImagemUrl = produto.ImagemUrl,
                Observacao = produto.Observacao,
                CreatedAt = produto.CreatedAt,
                UpdatedAt = produto.UpdatedAt
            }).ToList()

        };
    }
}

