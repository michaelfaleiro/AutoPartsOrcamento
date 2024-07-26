using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response.Item;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetById;

public class GetByIdCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseCotacaoJson>> Execute(Guid id)
    {
        var cotacao = await _dbContext.Cotacao
            .Include(x=> x.Orcamento)
            .ThenInclude(x=> x.Cliente)
            .Include(x=> x.Orcamento)
            .ThenInclude(x=> x.Veiculo)
            .Include(cotacao => cotacao.CotacaoItems)
            .FirstOrDefaultAsync(cotacao => cotacao.Id == id);

        if (cotacao is null)
        {
            throw new NotFoundException("Cotação não encontrada");
        }

        return new Response<ResponseCotacaoJson>()
        {
            Data = new ResponseCotacaoJson
            {
                Id = cotacao.Id,
                Cliente = new ResponseClienteJson
                {
                    Id = cotacao.Orcamento.Cliente.Id,
                    Nome = cotacao.Orcamento.Cliente.Nome,
                    Email = cotacao.Orcamento.Cliente.Email,
                    Telefone = cotacao.Orcamento.Cliente.Telefone
                },
                Veiculo = new ResponseVeiculoJson
                {
                    Id = cotacao.Orcamento.Veiculo.Id,
                    Marca = cotacao.Orcamento.Veiculo.Marca,
                    Modelo = cotacao.Orcamento.Veiculo.Modelo,
                    Ano = cotacao.Orcamento.Veiculo.Ano,
                    Chassi = cotacao.Orcamento.Veiculo.Chassi,
                    Placa = cotacao.Orcamento.Veiculo.Placa
                },
                Items = cotacao.CotacaoItems.Select(cotacaoItem => new ResponseItemCotacaoJson()
                {
                    Id = cotacaoItem.Id,
                    Nome = cotacaoItem.Nome,
                    Sku = cotacaoItem.Sku,
                    Quantidade = cotacaoItem.Quantidade,
                    Tipo = cotacaoItem.Tipo,
                    CreatedAt = cotacaoItem.CreatedAt,
                    UpdatedAt = cotacaoItem.UpdatedAt
                }).ToList(),
                CreatedAt = cotacao.CreatedAt,
                UpdatedAt = cotacao.UpdatedAt
            }
        };
    }
}
