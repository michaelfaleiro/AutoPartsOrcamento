using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Search;

public class SearchClienteByNomeTelefoneVeiculoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<PagedResponse<ResponseClienteComVeiculosJson>> Execute(SearchClienteRequest request)
    {
        var clientes = await _dbContext.Clientes
            .AsNoTracking()
            .Include(x => x.ClienteVeiculos)
            .ThenInclude(x => x.Veiculo)
            .Where(c => c.Nome.Contains(request.Query)
                        || c.Telefone.Contains(request.Query)
                        || c.ClienteVeiculos.Any(cv =>
                            cv.Veiculo.Placa.Contains(request.Query))).ToListAsync();


        return new PagedResponse<ResponseClienteComVeiculosJson>()
        {
            Data = clientes.Select(c => new ResponseClienteComVeiculosJson()
            {
                Id = c.Id,
                Nome = c.Nome,
                Telefone = c.Telefone,
                CpfCnpj = c.CpfCnpj,
                Email = c.Email,
                Veiculos = c.ClienteVeiculos.Select(v => new ResponseVeiculoJson
                {
                    Id = v.Veiculo.Id,
                    Marca = v.Veiculo.Marca,
                    Modelo = v.Veiculo.Modelo,
                    Ano = v.Veiculo.Ano,
                    Placa = v.Veiculo.Placa,
                    Renavam = v.Veiculo.Renavam,
                    Chassi = v.Veiculo.Chassi,
                    CreatedAt = v.CreatedAt,
                    UpdatedAt = v.UpdatedAt
                }).ToList(),
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            }).ToList()
        };
    }

}