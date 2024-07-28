using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarPrecoItem;

public class AdicionarPrecoItemCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(AdicionarPrecoItemCotacaoRequest request)
    {
        
        Validate(request);
        
        var cotacao = await _dbContext.Cotacao
            .Include(c => c.CotacaoItems)
            .ThenInclude(x=> x.PrecoItemCotacoes)
            .ThenInclude(x=> x.Fornecedor)
            .FirstOrDefaultAsync(c => c.Id == request.CotacaoId);

        if (cotacao == null)
        {
            throw new NotFoundException("Cotação não encontrada");
        }

        var item = cotacao.CotacaoItems.FirstOrDefault(i => i.Id == request.ItemId);

        if (item == null)
        {
            throw new NotFoundException("Item não encontrado");
        }

        var fornecedor = await _dbContext.Fornecedores
            .FirstOrDefaultAsync(f => f.Id == request.FornecedorId);

        if (fornecedor == null)
        {
            throw new NotFoundException("Fornecedor não encontrado");
        }

        var precoItem = new PrecoItemCotacao()
        {
            CotacaoItem = item,
            Fornecedor = fornecedor,
            QuantidadeAtendida = request.QuantidadeAtendida,
            Sku = request.Sku,
            Fabricante = request.Fabricante,
            ValorCusto = request.ValorCusto,
            ValorVenda = request.ValorVenda,
            PrazoExpedicao = request.PrazoExpedicao,
            Observacao = request.Observacao
        };

        await _dbContext.PrecoItemCotacoes.AddAsync(precoItem);

        await _dbContext.SaveChangesAsync();
    }

    private void Validate(AdicionarPrecoItemCotacaoRequest request)
    {
        
        var validator = new AdicionarPrecoItemCotacaoValidator();

        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;
        var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}