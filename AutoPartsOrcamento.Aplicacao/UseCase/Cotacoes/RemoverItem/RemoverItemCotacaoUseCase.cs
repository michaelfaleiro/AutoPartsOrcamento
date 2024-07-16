using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverItem;

public class RemoverItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(RemoverItemCotacaoRequest request)
    {
        Validate(request);

        var cotacao = await _dbContext.Cotacao
            .Include(cotacao => cotacao.CotacaoItems)
            .FirstOrDefaultAsync(cotacao => cotacao.Id == request.CotacaoId);

        if (cotacao is null)
        {
            throw new NotFoundException("Cotação não encontrada");
        }

        var cotacaoItem = cotacao.CotacaoItems.FirstOrDefault(cotacaoItem => cotacaoItem.Id == request.ItemId);

        if (cotacaoItem is null)
        {
            throw new NotFoundException("Item da cotação não encontrado");
        }

        _dbContext.CotacaoItems.Remove(cotacaoItem);
        await _dbContext.SaveChangesAsync();
    }

    private void Validate(RemoverItemCotacaoRequest request)
    {
        var validator = new RemoverItemCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;

        var errors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ErrorOnValidateException(errors.ToList());
    }
    
}