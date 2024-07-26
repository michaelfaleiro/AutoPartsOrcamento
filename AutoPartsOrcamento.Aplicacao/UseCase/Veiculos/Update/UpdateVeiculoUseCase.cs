using AutoPartsOrcamento.Comunicacao.Request.Veiculo;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Update;

public class UpdateVeiculoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseVeiculoJson>> Execute(Guid id, UpdateVeiculoRequest request)
    {
        Validate(request);
        
        var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == id);

        if (veiculo is null)
        {
            throw new NotFoundException("Veículo não encontrado.");
        }

        veiculo.Marca = request.Marca;
        veiculo.Modelo = request.Modelo;
        veiculo.Ano = request.Ano;
        veiculo.Placa = request.Placa;
        veiculo.Chassi = request.Chassi;
        veiculo.Renavam = request.Renavam;
        veiculo.UpdatedAt = DateTime.Now;

        _dbContext.Veiculos.Update(veiculo);
        await _dbContext.SaveChangesAsync();

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

    private void Validate(UpdateVeiculoRequest request)
    {
        var validator = new UpdateVeiculoValidator();
        
        var result = validator.Validate(request);
        
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidateException(errorMessages);
        }
    }
    
}