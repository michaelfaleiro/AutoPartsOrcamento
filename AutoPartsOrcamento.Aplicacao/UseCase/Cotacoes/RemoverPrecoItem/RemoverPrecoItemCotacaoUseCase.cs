using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverPrecoItem;

public class RemoverPrecoItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(RemoverPrecoItemCotacaoRequest request)
    {
        Validate(request);
        
        var cotacao = await _dbContext.Cotacao
            .Include(c => c.CotacaoItems)
            .FirstOrDefaultAsync(c => c.Id == request.CotacaoId);

        if (cotacao is null)
            throw new NotFoundException("Cotação não encontrada");
        
        var item = cotacao.CotacaoItems.FirstOrDefault(i => i.Id == request.ItemId);
        
        if (item is null)
            throw new NotFoundException("Item não encontrado");
        
        cotacao.CotacaoItems.Remove(item);
        
        await _dbContext.SaveChangesAsync();
    }

    private void Validate(RemoverPrecoItemCotacaoRequest request)
    {
        
        var validator = new RemoverPrecoItemCotacaoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidateException(errors);
        }
    }
    
}