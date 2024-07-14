using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.RemoverVeiculoCliente;

public class RemoverVeiculoClienteUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(RemoverVeiculoClienteRequest request)
    {
        var clienteVeiculo = dbContext.ClienteVeiculos;
        
        var clienteVeiculoEntity = clienteVeiculo
            .FirstOrDefault(x => x.ClienteId == request.ClienteId && x.VeiculoId == request.VeiculoId);
        
        if (clienteVeiculoEntity is null)
        {
            throw new NotFoundException("Veículo não cadastrado para o cliente");
        }
        
        clienteVeiculo.Remove(clienteVeiculoEntity);
        
        await _dbContext.SaveChangesAsync();
        
    }
    
}