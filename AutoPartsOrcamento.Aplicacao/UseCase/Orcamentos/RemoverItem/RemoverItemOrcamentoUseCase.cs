using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response.Orcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.RemoverItem;

public class RemoverItemOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(RemoverItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _dbContext.Orcamentos
            .Include(orcamento => orcamento.OrcamentoItems)
            .FirstOrDefaultAsync(orcamento => orcamento.Id == request.OrcamentoId);

        if (orcamento is null)
        {
            throw new NotFoundException("Orçamento não encontrado");
        }

        var orcamentoItem = orcamento.OrcamentoItems
            .FirstOrDefault(orcamentoItem => orcamentoItem.Id == request.ItemId);

        if (orcamentoItem is null)
        {
            throw new NotFoundException("Item do orçamento não encontrado");
        }

        _dbContext.OrcamentoItens.Remove(orcamentoItem);
        await _dbContext.SaveChangesAsync();
    }

    private void Validate(RemoverItemOrcamentoRequest request)
    {
        var validator = new RemoverItemOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidateException(errorMessages);
        }
    }
    
}