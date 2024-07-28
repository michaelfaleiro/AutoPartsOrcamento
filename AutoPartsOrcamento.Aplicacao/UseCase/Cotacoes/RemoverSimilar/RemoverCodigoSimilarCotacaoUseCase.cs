using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverSimilar;

public class RemoverCodigoSimilarCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(Guid id)
    {
        var codigoSimilar = await _dbContext.CodigoSimilarProdutos
            .FirstOrDefaultAsync(x => x.Id == id);

        if (codigoSimilar == null)
        {
            throw new NotFoundException("Código similar não encontrado");
        }

        _dbContext.CodigoSimilarProdutos.Remove(codigoSimilar);

        await _dbContext.SaveChangesAsync();
    }
    
}