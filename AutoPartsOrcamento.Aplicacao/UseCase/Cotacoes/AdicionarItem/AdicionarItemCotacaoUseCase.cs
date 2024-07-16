using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarItem;

public class AdicionarItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(AdicionarItemCotacaoRequest request)
    {
        Validate(request);

        var cotacao = await _dbContext.Cotacao
            .Include(cotacao => cotacao.CotacaoItems)
            .FirstOrDefaultAsync(cotacao => cotacao.Id == request.CotacaoId);

        if (cotacao is null)
        {
            throw new NotFoundException("Cotação não encontrada");
        }
        
        var cotacaoItem = new CotacaoItem
        {
            Cotacao = cotacao,
            Nome = request.Nome,
            Sku = request.Sku,
            Quantidade = request.Quantidade,
            Tipo = request.Tipo
        };

        await _dbContext.CotacaoItems.AddAsync(cotacaoItem);
        await _dbContext.SaveChangesAsync();
    }

    private void Validate(AdicionarItemCotacaoRequest request)
    {
        var validator = new AdicionarItemCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;
        
        var errors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ErrorOnValidateException(errors.ToList());
    }
    
}