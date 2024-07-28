using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdatePrecoItem;

public class UpdatePrecoItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(UpdatePrecoItemCotacaoRequest request)
    {
        Validate(request);
        
        var item = await _dbContext.CotacaoItems
            .Include(i => i.PrecoItemCotacoes)
            .FirstOrDefaultAsync(i => i.Id == request.ItemId);
        
        if (item == null)
            throw new NotFoundException("Item não encontrado");
        
        var precoItem = item.PrecoItemCotacoes.FirstOrDefault(p => p.Id == request.PrecoItemId);
        
        if (precoItem == null)
            throw new NotFoundException("Preço do item não encontrado");
        
        var fornecedor = await _dbContext.Fornecedores
            .FirstOrDefaultAsync(f => f.Id == request.FornecedorId);
        
        if (fornecedor == null)
            throw new NotFoundException("Fornecedor não encontrado");
        
        precoItem.QuantidadeAtendida = request.QuantidadeAtendida;
        precoItem.Sku = request.Sku;
        precoItem.Fabricante = request.Fabricante;
        precoItem.ValorCusto = request.ValorCusto;
        precoItem.ValorVenda = request.ValorVenda;
        precoItem.PrazoExpedicao = request.PrazoExpedicao;
        precoItem.Observacao = request.Observacao;
        precoItem.Fornecedor = fornecedor;
        precoItem.UpdatedAt = DateTime.UtcNow;
        
        _dbContext.PrecoItemCotacoes.Update(precoItem);
        
        await _dbContext.SaveChangesAsync();
    }
    
    private void Validate(UpdatePrecoItemCotacaoRequest request)
    {
        
        var validator = new UpdatePrecoItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
    
}