using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.Register;

public class RegisterCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(CreateCotacaoRequest request)
    {
        Validate(request);
        
        var orcamento = await _dbContext.Orcamentos
            .Include(orcamento => orcamento.OrcamentoItems)
            .FirstOrDefaultAsync(orcamento => orcamento.Id == request.OrcamentoId);
        
        if(orcamento is null)
        {
            throw new NotFoundException("Orçamento não encontrado");
        }
        
        var cotacao = new Cotacao
        {
            Orcamento = orcamento
        };

        await _dbContext.Cotacao.AddAsync(cotacao);
        await _dbContext.SaveChangesAsync();
    }

    private void Validate(CreateCotacaoRequest request)
    {
        var validator = new RegisterCotacaoValidator();
        var validationResult = validator.Validate(request);
        
        if(validationResult.IsValid is false)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage);
            throw new ErrorOnValidateException(errors.ToList());
        }
    }
    
}