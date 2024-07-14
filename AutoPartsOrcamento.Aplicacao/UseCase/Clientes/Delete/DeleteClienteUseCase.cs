using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Delete;

public class DeleteClienteUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(Guid id)
    {
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

        if (cliente == null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        _dbContext.Clientes.Remove(cliente);
        await _dbContext.SaveChangesAsync();
        
    }
}
