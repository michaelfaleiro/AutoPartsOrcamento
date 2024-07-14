using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.GetById;

public class GetByIdProdutoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseProdutoJson>> Execute(Guid id)
    {
        var produto = await _dbContext.Produtos.FindAsync(id);

        if (produto == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }

        return new Response<ResponseProdutoJson>
        {
            Data =  [new ResponseProdutoJson
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
            }]
        };
    }
    
}