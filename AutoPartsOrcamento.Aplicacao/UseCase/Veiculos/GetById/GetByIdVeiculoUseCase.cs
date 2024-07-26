using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;


namespace AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.GetById;

public class GetByIdVeiculoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseVeiculoJson>> Execute(Guid id)
    {
        var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == id);

        if (veiculo is null)
        {
            throw new NotFoundException("Veículo não encontrado.");
        }

        return new Response<ResponseVeiculoJson>
        {
            Data = new ResponseVeiculoJson
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                Chassi = veiculo.Chassi,
                Renavam = veiculo.Renavam,
                CreatedAt = veiculo.CreatedAt,
                UpdatedAt = veiculo.UpdatedAt
            }
        };
    }
    
}