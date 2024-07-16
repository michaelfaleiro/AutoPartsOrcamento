using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateItem;

public class UpdateItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(UpdateItemCotacaoRequest request)
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

        cotacaoItem.Nome = request.Nome;
        cotacaoItem.Quantidade = request.Quantidade;
        cotacaoItem.Tipo = request.Tipo;

        await _dbContext.SaveChangesAsync();
    }

    private void Validate(UpdateItemCotacaoRequest request)
    {
        var validator = new UpdateItemCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;

        var errors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ErrorOnValidateException(errors.ToList());
    }
    
}