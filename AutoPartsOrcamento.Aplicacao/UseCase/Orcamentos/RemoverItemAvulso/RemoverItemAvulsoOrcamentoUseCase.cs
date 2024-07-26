using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.RemoverItemAvulso;

public class RemoverItemAvulsoOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(RemoverItemAvulsoOrcamentoRequest request)
    {
        Validate(request);
        
        var orcamento = await _dbContext.Orcamentos
            .Include(o => o.OrcamentoItemAvulsos)
            .FirstOrDefaultAsync(o => o.Id == request.OrcamentoId);

        if (orcamento == null)
            throw new NotFoundException("Orçamento não encontrado");

        var item = orcamento.OrcamentoItemAvulsos.FirstOrDefault(i => i.Id == request.ItemId);

        if (item == null)
            throw new NotFoundException("Item não encontrado");

        orcamento.OrcamentoItemAvulsos.Remove(item);

        await _dbContext.SaveChangesAsync();
    }
    
    private void Validate(RemoverItemAvulsoOrcamentoRequest request)
    {
        var validator = new RemoverItemAvulsoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();        
            throw new ErrorOnValidateException(errors);
        }
    }
    
}