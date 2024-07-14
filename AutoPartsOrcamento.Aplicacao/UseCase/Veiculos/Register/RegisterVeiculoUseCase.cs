using AutoPartsOrcamento.Comunicacao.Request.Veiculo;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Infra.Entities;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Register;

public class RegisterVeiculoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseVeiculoJson>> Execute(CreateVeiculoRequest createVeiculoRequest)
    {

        ValidateRequest(createVeiculoRequest);

        var veiculo = new Veiculo
        {
            Marca = createVeiculoRequest.Marca,
            Modelo = createVeiculoRequest.Modelo,
            Ano = createVeiculoRequest.Ano,
            Placa = createVeiculoRequest.Placa,
            Renavam = createVeiculoRequest.Renavam,
            Chassi = createVeiculoRequest.Chassi,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _dbContext.Veiculos.AddAsync(veiculo);
        await _dbContext.SaveChangesAsync();

        return new Response<ResponseVeiculoJson>()
        {
            Data = [new ResponseVeiculoJson
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                Renavam = veiculo.Renavam,
                Chassi = veiculo.Chassi,
                CreatedAt = veiculo.CreatedAt,
                UpdatedAt = veiculo.UpdatedAt
            }]
        };
    }
    
    private void ValidateRequest(CreateVeiculoRequest createVeiculoRequest)
    {
        var validator = new RegisterVeiculoValidator();
        
        var result = validator.Validate(createVeiculoRequest);
        
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidateException(errorMessages);
        }
    }

}