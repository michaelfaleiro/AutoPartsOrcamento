using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetAll;

public class GetAllOrcamentosUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseOrcamentoJson>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.Orcamentos
            .Include(x=> x.Cliente)
            .Include(x=> x.Veiculo)
            .AsQueryable();
        
        var orcamentos = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = orcamentos.Count;

        return new PagedResponse<ResponseOrcamentoJson>()
        {
            CurrentPage = pageNumber,
            PageSize =  pageSize,
            TotalCount = count,
            Data = orcamentos.Select(orcamento => new ResponseOrcamentoJson
            {
                Id = orcamento.Id,
                Cliente = new ResponseClienteJson
                {
                    Id = orcamento.Cliente.Id,
                    Nome = orcamento.Cliente.Nome,
                    Telefone = orcamento.Cliente.Telefone,
                    CpfCnpj = orcamento.Cliente.CpfCnpj,
                    Email = orcamento.Cliente.Email,
                    CreatedAt = orcamento.Cliente.CreatedAt,
                    UpdatedAt = orcamento.Cliente.UpdatedAt
                },
                Veiculo = new ResponseVeiculoJson
                {
                    Id = orcamento.Veiculo.Id,
                    Marca = orcamento.Veiculo.Marca,
                    Modelo = orcamento.Veiculo.Modelo,
                    Ano = orcamento.Veiculo.Ano,
                    Placa = orcamento.Veiculo.Placa,
                    Renavam = orcamento.Veiculo.Renavam,
                    Chassi = orcamento.Veiculo.Chassi,
                    CreatedAt = orcamento.Veiculo.CreatedAt,
                    UpdatedAt = orcamento.Veiculo.UpdatedAt
                },
                CreatedAt = orcamento.CreatedAt,
                UpdatedAt = orcamento.UpdatedAt
            }).ToList()
        };
    }
    
}