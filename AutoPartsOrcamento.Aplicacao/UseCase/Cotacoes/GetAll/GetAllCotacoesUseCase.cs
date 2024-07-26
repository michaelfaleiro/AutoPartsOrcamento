using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetAll;

public class GetAllCotacoesUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<PagedResponse<ResponseCotacaoJson>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.Cotacao
            .AsNoTracking()
            .Include(x=>x.Orcamento)
                .ThenInclude(x=> x.Cliente)
            .Include(x=> x.Orcamento)
                .ThenInclude(x=> x.Veiculo)
            .Include(x=> x.Status);
        
        var cotacoes = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = await query.CountAsync();

        return new PagedResponse<ResponseCotacaoJson>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            Data = cotacoes.Select(cotacao => new ResponseCotacaoJson
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
                    Ano = cotacao.Orcamento.Veiculo.Ano
                },
                Status = cotacao.Status.Nome
            }).ToList()
        };
    }
    
}