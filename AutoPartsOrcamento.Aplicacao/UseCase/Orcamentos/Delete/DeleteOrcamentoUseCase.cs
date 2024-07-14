using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Delete;

public class DeleteOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(Guid id)
    {
        var orcamento = await _dbContext.Orcamentos.FirstOrDefaultAsync(x=> x.Id == id);
            
        if (orcamento is null)
        {
            throw new NotFoundException("Orçamento não encontrado");
        }

        _dbContext.Orcamentos.Remove(orcamento);
        await _dbContext.SaveChangesAsync();
    }
    
}