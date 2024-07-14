using AutoPartsOrcamento.Comunicacao.Request.Produto;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Update;

public class UpdateProdutoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<ResponseProdutoJson> Execute(Guid id, UpdateProdutoRequest request)
    {
        var produto = await _dbContext.Produtos.FindAsync(id);

        if (produto == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }

        produto.Sku = request.Sku;
        produto.Nome = request.Nome;
        produto.Fabricante = request.Fabricante;
        produto.Descricao = request.Descricao;
        produto.ValorCusto = request.ValorCusto;
        produto.ValorVenda = request.ValorVenda;
        produto.ImagemUrl = request.ImagemUrl;
        produto.Observacao = request.Observacao;
        produto.UpdatedAt = DateTime.Now;

        await _dbContext.SaveChangesAsync();
        
        return new ResponseProdutoJson
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
        };
    }
    
}