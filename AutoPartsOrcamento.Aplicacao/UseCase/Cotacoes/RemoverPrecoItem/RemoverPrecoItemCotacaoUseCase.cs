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
        
        var item = await _dbContext.CotacaoItems
            .Include(c => c.PrecoItemCotacoes)
            .FirstOrDefaultAsync(c => c.Id == request.ItemId);
       
       
        if (item is null)
            throw new NotFoundException("Item não encontrado");
        
        var precoItem = item.PrecoItemCotacoes.FirstOrDefault(p => p.Id == request.PrecoItemId);
        
        if (precoItem is null)
            throw new NotFoundException("Preço do item não encontrado");
        
        item.PrecoItemCotacoes.Remove(precoItem);
        
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