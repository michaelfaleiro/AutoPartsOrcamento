using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response.ItemAvulso;
using AutoPartsOrcamento.Comunicacao.Response.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetById;

public class GetByIdOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseOrcamentoJson>> Execute(Guid id)
    {
        var orcamento = await _dbContext.Orcamentos
            .Include(x => x.Cliente)
            .Include(x => x.Veiculo)
            .Include(x => x.OrcamentoItems)
            .ThenInclude(x => x.Produto)
            .Include(x => x.OrcamentoItemAvulsos)
            .Include(x => x.Cotacoes)
            .Include(x=> x.Status)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (orcamento is null)
        {
            throw new NotFoundException("Orçamento não encontrado");
        }
        
        var valorTotalItems = orcamento.OrcamentoItems
            .Sum(item => item.Quantidade * item.ValorVenda);

        var valorTotalItemAvulsos = orcamento.OrcamentoItemAvulsos
            .Sum(item => item.Quantidade * item.ValorVenda);

        var total = valorTotalItems + valorTotalItemAvulsos;

        return new Response<ResponseOrcamentoJson>()
        {
            Data =
                new ResponseOrcamentoJson
                {
                    Id = orcamento.Id,
                    Cliente = new ResponseClienteJson
                    {
                        Id = orcamento.Id,
                        Nome = orcamento.Cliente.Nome,
                        Telefone = orcamento.Cliente.Telefone,
                        CpfCnpj = orcamento.Cliente.CpfCnpj,
                        Email = orcamento.Cliente.Email,
                        CreatedAt = orcamento.CreatedAt,
                        UpdatedAt = orcamento.UpdatedAt
                    },
                    Veiculo = new ResponseVeiculoJson
                    {
                        Id = orcamento.Id,
                        Marca = orcamento.Veiculo.Marca,
                        Modelo = orcamento.Veiculo.Modelo,
                        Ano = orcamento.Veiculo.Ano,
                        Placa = orcamento.Veiculo.Placa,
                        Renavam = orcamento.Veiculo.Renavam,
                        Chassi = orcamento.Veiculo.Chassi,
                        CreatedAt = orcamento.CreatedAt,
                        UpdatedAt = orcamento.UpdatedAt
                    },
                    Items = orcamento.OrcamentoItems.Select(x => new ResponseOrcamentoItemJson
                    {
                        Id = x.Id,
                        ProdutoId = x.ProdutoId,
                        OrcamentoId = x.Orcamento.Id,
                        Sku = x.Produto.Sku,
                        Nome = x.Produto.Nome,
                        Fabricante = x.Produto.Fabricante,
                        Quantidade = x.Quantidade,
                        ValorUnitario = x.ValorVenda,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    }).ToList(),
                    ItemAvulsos = orcamento.OrcamentoItemAvulsos.Select(x => new ResponseItemAvulsoJson
                    {
                        Id = x.Id,
                        OrcamentoId = x.Orcamento.Id,
                        Sku = x.Sku,
                        Nome = x.Nome,
                        Fabricante = x.Fabricante,
                        Quantidade = x.Quantidade,
                        ValorVenda = x.ValorVenda,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    }).ToList(),
                    Cotacoes = orcamento.Cotacoes.Select(x => new ResponseCotacaoJson
                    {
                        Id = x.Id,
                        Items = [],
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    }).ToList(),
                    Status = orcamento.Status.Nome,    
                    ValorTotal = total,
                    CreatedAt = orcamento.CreatedAt,
                    UpdatedAt = orcamento.UpdatedAt
                }
        };
    }
}