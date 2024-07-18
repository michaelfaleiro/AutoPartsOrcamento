using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes
    .Delete;

public class DeleteStatusCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(Guid id)
    {
        var statusCotacao = await _dbContext.StatusCotacoes
            .FirstOrDefaultAsync(x => x.Id == id);

        if (statusCotacao == null)
        {
            throw new Exception("Status da cotacao não encontrado");
        }

        _dbContext.StatusCotacoes.Remove(statusCotacao);
        
        await _dbContext.SaveChangesAsync();
    }
    
}