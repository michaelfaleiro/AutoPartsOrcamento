using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.AdicionarItemAvulso;

public class AdicionarItemAvulsoOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(AdicionarItemAvulsoOrcamentoRequest request)
    {
        Validate(request);
        
        var orcamento = await _dbContext.Orcamentos
            .Include(x=> x.OrcamentoItemAvulsos)
            .FirstOrDefaultAsync(o => o.Id == request.OrcamentoId);

        if (orcamento == null)
            throw new NotFoundException("Orçamento não encontrado");
        
        if (orcamento.OrcamentoItemAvulsos.Any(x => x.Sku == request.Sku))
            throw new BusinessException(["Item já adicionado ao orçamento"]);
        
        var item = new OrcamentoItemAvulso()
        {
            Orcamento = orcamento,
            Sku = request.Sku,
            Nome = request.Nome,
            Fabricante = request.Fabricante,
            Quantidade = request.Quantidade,
            ValorVenda = request.ValorVenda
        };

        await _dbContext.OrcamentoItemAvulsos.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }
    
    private void Validate(AdicionarItemAvulsoOrcamentoRequest request)
    {
        var validator = new AdicionarItemAvulsoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();        
            throw new ErrorOnValidateException(errors);
        }
    }
}