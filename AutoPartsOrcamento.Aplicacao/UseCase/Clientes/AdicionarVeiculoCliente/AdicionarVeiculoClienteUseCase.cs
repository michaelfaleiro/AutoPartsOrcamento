using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.AdicionarVeiculoCliente;

public class AdicionarVeiculoClienteUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(AdicionarVeiculoClienteRequest request)
    {
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == request.ClienteId);

        if (cliente == null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == request.VeiculoId);

        if (veiculo == null)
        {
            throw new NotFoundException("Veículo não encontrado");
        }

        var clienteVeiculo = dbContext.ClienteVeiculos;
        
        if (clienteVeiculo.Any(x => x.ClienteId == cliente.Id && x.VeiculoId == veiculo.Id))
        {
            throw new BusinessException(["Veículo já cadastrado para o cliente"]);
        }
        
        clienteVeiculo.Add(new ClienteVeiculo
        {
            ClienteId = cliente.Id,
            VeiculoId = veiculo.Id
        });
        
        await _dbContext.SaveChangesAsync();
        
    }
}