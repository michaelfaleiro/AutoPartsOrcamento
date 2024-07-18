using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Delete;

public class DeleteStatusOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(Guid id)
    {
        var statusOrcamento = await _dbContext.StatusOrcamentos
            .FirstOrDefaultAsync(x => x.Id == id);

        if (statusOrcamento == null)
        {
            throw new Exception("Status do orçamento não encontrado");
        }

        _dbContext.StatusOrcamentos.Remove(statusOrcamento);
        
        await _dbContext.SaveChangesAsync();
    }
    
}