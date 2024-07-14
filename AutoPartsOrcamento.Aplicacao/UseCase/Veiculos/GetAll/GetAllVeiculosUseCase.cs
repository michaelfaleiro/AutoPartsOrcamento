using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.GetAll;

public class GetAllVeiculosUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<IList<ResponseVeiculoJson>>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.Veiculos.AsQueryable();
        
        var veiculos = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = await query.CountAsync();
        
        return new Response<IList<ResponseVeiculoJson>>
        {
            Data = [veiculos.Select(x => new ResponseVeiculoJson
            {
                Id = x.Id,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Ano = x.Ano,
                Placa = x.Placa,
                Chassi = x.Chassi,
                Renavam = x.Renavam,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
                
            }).ToList()]
        };
        
    }
    
}