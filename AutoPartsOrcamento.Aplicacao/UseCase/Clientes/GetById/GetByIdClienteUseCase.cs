using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetById;

public class GetByIdClienteUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseClienteComVeiculosJson>> Execute(Guid id)
    {
        var cliente = await _dbContext.Clientes
            .Include(x => x.ClienteVeiculos)
            .ThenInclude(clienteVeiculo => clienteVeiculo.Veiculo)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        return new Response<ResponseClienteComVeiculosJson>()
        {
            Data = [new ResponseClienteComVeiculosJson
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                CpfCnpj = cliente.CpfCnpj,
                Email = cliente.Email,
                Veiculos =  cliente.ClienteVeiculos.Select(x => new ResponseVeiculoJson
                {
                    Id = x.Veiculo.Id,
                    Marca = x.Veiculo.Marca,
                    Modelo = x.Veiculo.Modelo,
                    Ano = x.Veiculo.Ano,
                    Placa = x.Veiculo.Placa,
                    Renavam = x.Veiculo.Renavam,
                    Chassi = x.Veiculo.Chassi,
                    CreatedAt = x.Veiculo.CreatedAt,
                    UpdatedAt = x.Veiculo.UpdatedAt
                }).ToList(),
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt
            }]
        };
    }
}