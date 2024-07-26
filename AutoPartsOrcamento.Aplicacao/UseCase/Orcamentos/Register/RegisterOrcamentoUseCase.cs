using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Register;

public class RegisterOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseOrcamentoJson>> Execute(CreateOrcamentoRequest request)
    {
        Validate(request);
        
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == request.ClienteId);
        
        if (cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        
        var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == request.VeiculoId);
        
        if (veiculo is null)
        {
            throw new NotFoundException("Veículo não encontrado.");
        }
        
        var status = await _dbContext.StatusOrcamentos.FirstOrDefaultAsync(x => x.Id == request.StatusId);
        
        if (status is null)
        {
            throw new NotFoundException("Status não encontrado.");
        }
        
        
        var orcamento = new Orcamento
        {
            Cliente = cliente,
            Veiculo = veiculo,
            Status = status
        };
        
        await _dbContext.Orcamentos.AddAsync(orcamento);
        await _dbContext.SaveChangesAsync();

        return new Response<ResponseOrcamentoJson>()
        {
            Data =
            
                new ResponseOrcamentoJson
                {
                    Id = orcamento.Id,
                    Cliente = new ResponseClienteJson
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        Telefone = cliente.Telefone,
                        CpfCnpj = cliente.CpfCnpj,
                        Email = cliente.Email,
                        CreatedAt = cliente.CreatedAt,
                        UpdatedAt = cliente.UpdatedAt
                    },
                    Veiculo = new ResponseVeiculoJson
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
                    },
                    CreatedAt = orcamento.CreatedAt,
                    UpdatedAt = orcamento.UpdatedAt
                }
            
        };
    }
    
    private void Validate(CreateOrcamentoRequest request)
    {
        var validator = new RegisterOrcamentoValidator();
        
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;
        var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}