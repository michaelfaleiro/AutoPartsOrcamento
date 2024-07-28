using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateSimilar;

public class UpdateCodigoSimilarCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(UpdateCodigoSimilarCotacaoRequest request)
    {
        var codigoSimilar = await _dbContext.CodigoSimilarProdutos
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (codigoSimilar is null)
        {
            throw new NotFoundException("Código similar não encontrado");
        }

        codigoSimilar.Sku = request.Sku;
        codigoSimilar.Fabricante = request.Fabricante;
        codigoSimilar.Tipo = request.Tipo;

        await _dbContext.SaveChangesAsync();
    }
    
    
    
}