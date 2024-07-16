using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.UpdateItem;

public class UpdateItemOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(UpdateItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamentoItem = await _dbContext.OrcamentoItens
            .FirstOrDefaultAsync(orcamentoItem =>
                orcamentoItem.OrcamentoId == request.OrcamentoId
                && orcamentoItem.ProdutoId == request.ProdutoId);

        if (orcamentoItem is null)
        {
            throw new NotFoundException("Item do orçamento não encontrado");
        }

        orcamentoItem.Quantidade = request.Quantidade;
        orcamentoItem.ValorUnitario = request.ValorUnitario;

        await _dbContext.SaveChangesAsync();
    }

    private void Validate(UpdateItemOrcamentoRequest request)
    {
        var validator = new UpdateItemOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidateException(errorMessages);
        }
        
    }
    
}