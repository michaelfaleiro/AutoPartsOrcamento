using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.AdicionarItem;

public class AdicionarItemOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(AdicionarItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _dbContext.Orcamentos
            .Include(orcamento => orcamento.OrcamentoItems)
            .FirstOrDefaultAsync(orcamento => orcamento.Id == request.OrcamentoId);

        if (orcamento is null)
        {
            throw new NotFoundException("Orçamento não encontrado");
        }

        var produto = await _dbContext.Produtos
            .FirstOrDefaultAsync(produto => produto.Id == request.ProdutoId);

        if (produto is null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        
        if (orcamento.OrcamentoItems.Any(orcamentoItem => orcamentoItem.ProdutoId == request.ProdutoId))
        {
            throw new BusinessException(["Produto já adicionado ao orçamento"]);
        }
        
        var orcamentoItem = new OrcamentoItem
        {
            OrcamentoId = request.OrcamentoId,
            ProdutoId = request.ProdutoId,
            Quantidade = request.Quantidade,
            ValorUnitario = request.ValorUnitario
        };

        await _dbContext.OrcamentoItens.AddAsync(orcamentoItem);
        await _dbContext.SaveChangesAsync();
    }

    private void Validate(AdicionarItemOrcamentoRequest request)
    {
        var validator = new AdicionarItemOrcamentoValidator();
        var result = validator.Validate(request);
        
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidateException(errorMessages);
        }
    }
    
}