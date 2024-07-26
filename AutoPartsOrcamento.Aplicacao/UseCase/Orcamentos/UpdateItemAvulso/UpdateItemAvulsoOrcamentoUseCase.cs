using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.UpdateItemAvulso;

public class UpdateItemAvulsoOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(UpdateItemAvulsoOrcamentoRequest request)
    {
        
        var item = await _dbContext.OrcamentoItemAvulsos
            .Where(x => x.Orcamento.Id == request.OrcamentoId)
            .FirstOrDefaultAsync(x => x.Id == request.ItemId);

        if (item == null)
        {
            throw new Exception("Item não encontrado");
        }

        item.Nome = request.Nome;
        item.Fabricante = request.Fabricante;
        item.Quantidade = request.Quantidade;
        item.ValorVenda = request.ValorVenda;
        item.Sku = request.Sku;
        item.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
    }
    
    private void Validate(UpdateItemAvulsoOrcamentoRequest request)
    {
        var validator = new UpdateItemAvulsoOrcamentoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidateException(errors);
        }
    }
}