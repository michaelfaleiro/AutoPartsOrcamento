using AutoPartsOrcamento.Comunicacao.Request.Produto;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Infra.Entities;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Register;

public class RegisterProdutoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseProdutoJson>> Execute(CreateProdutoRequest request)
    {
        Validate(request);
        
        var produto = new Produto
        {
            Sku = request.Sku,
            Nome = request.Nome,
            Fabricante = request.Fabricante,
            Descricao = request.Descricao,
            ValorCusto = request.ValorCusto,
            ValorVenda = request.ValorVenda,
            ImagemUrl = request.ImagemUrl,
            Observacao = request.Observacao
        };

        await _dbContext.Produtos.AddAsync(produto);
        await _dbContext.SaveChangesAsync();

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
    
    private void Validate(CreateProdutoRequest request)
    {
        var validator = new RegisterProdutoValidator();
        var result = validator.Validate(request);
        
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            
            throw new ErrorOnValidateException(errors);
        }
    }
    
}