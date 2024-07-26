using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AlterarStatus;

public class AlterarStatusCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(AlterarStatusCotacaoRequest request)
    {
        Validate(request);
        
        var cotacao = await _dbContext.Cotacao
            .Include(cotacao => cotacao.Status)
            .FirstOrDefaultAsync(cotacao => cotacao.Id == request.CotacaoId);
        
        if(cotacao is null)
        {
            throw new NotFoundException("Cotação não encontrada");
        }
        
        var status = await _dbContext.StatusCotacoes
            .FirstOrDefaultAsync(status => status.Id == request.StatusId);
        
        if(status is null)
        {
            throw new NotFoundException("Status não encontrado");
        }
        
        cotacao.Status = status;

        await _dbContext.SaveChangesAsync();
    }

    private void Validate(AlterarStatusCotacaoRequest request)
    {
        var validator = new AlterarStatusCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid is true) return;
        var errors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ErrorOnValidateException(errors.ToList());
    }
    
}