using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarSimilar;

public class AdicionarCodigoSimilarCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(AdicionarCodigoSimilarCotacaoRequest request)
    {
        var item = await _dbContext.CotacaoItems
            .Include(x=> x.CodigoSimilares)
            .FirstOrDefaultAsync(x => x.Id == request.ItemId);

        if (item == null)
            throw new NotFoundException("Item não encontrado");

        var similar = new CodigoSimilarProduto()
        {
            CotacaoItem = item,
            Sku = request.Sku,
            Fabricante = request.Fabricante,
            Tipo = request.Tipo
        };

        await _dbContext.CodigoSimilarProdutos.AddAsync(similar);

        await _dbContext.SaveChangesAsync();
        
    }

    private void Validate(AdicionarCodigoSimilarCotacaoRequest request)
    {
        var validator = new AdicionarCodigoSimilarCotacaoValidator();

        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;
        var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
    
}