using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;
using AutoPartsOrcamento.Comunicacao.Response.Item;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetItem;

public class GetByIdItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseItemCotacaoJson>> Execute(Guid id)
    {
        var item = await _dbContext.CotacaoItems
            .Include(x => x.PrecoItemCotacoes)
            .ThenInclude(x => x.Fornecedor)
            .Include(x => x.CodigoSimilares)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
        {
            throw new NotFoundException("Item não encontrado");
        }

        return new Response<ResponseItemCotacaoJson>
        {
            Data = new ResponseItemCotacaoJson 
            {

                Id = item.Id,
                Quantidade = item.Quantidade,
                Nome = item.Nome,
                Sku = item.Sku,
                Tipo = item.Tipo,
                CodigoSimilares = item.CodigoSimilares.Select(x => new ResponseCodigoSimilarProdutoJson
                {
                    Id = x.Id,
                    Sku = x.Sku,
                    Fabricante = x.Fabricante,
                }).ToList(),
                PrecoItemCotacoes = item.PrecoItemCotacoes.Select(x => new ResponsePrecoItemCotacaoJson
                {
                    Id = x.Id,
                    QuantidadeAtendida = x.QuantidadeAtendida,
                    Sku = x.Sku,
                    Fabricante = x.Fabricante,
                    ValorCusto = x.ValorCusto,
                    ValorVenda = x.ValorVenda,
                    PrazoExpedicao = x.PrazoExpedicao,
                    Observacao = x.Observacao,
                    Fornecedor = new ResponseFornecedorJson
                    {
                        Id = x.Fornecedor.Id,
                        NomeFantasia = x.Fornecedor.NomeFantasia,
                        Cnpj = x.Fornecedor.Cnpj,
                        Telefone = x.Fornecedor.Telefone,
                        Email = x.Fornecedor.Email
                    },
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToList(),
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            }
        };
    }

}