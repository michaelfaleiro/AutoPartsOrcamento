using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdatePrecoItem;

public class UpdatePrecoItemCotacaoValidator : AbstractValidator<UpdatePrecoItemCotacaoRequest>
{
    public UpdatePrecoItemCotacaoValidator()
    {
        
        RuleFor(x=> x.PrecoItemId)
            .NotEmpty()
            .WithMessage("PrecoItemId não informado");
        
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item não informado");
        
        RuleFor(x => x.FornecedorId)
            .NotEmpty()
            .WithMessage("Fornecedor não informado");
        
        RuleFor(x => x.QuantidadeAtendida)
            .NotEmpty()
            .WithMessage("Quantidade atendida não informada");
        
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("SKU não informado");
        
        RuleFor(x => x.ValorCusto)
            .NotEmpty()
            .WithMessage("Valor de custo não informado");
        
        RuleFor(x => x.ValorVenda)
            .NotEmpty()
            .WithMessage("Valor de venda não informado");
        
        RuleFor(x => x.PrazoExpedicao)
            .NotEmpty()
            .WithMessage("Prazo de expedição não informado");
        
        RuleFor(x=> x.Fabricante)
            .NotEmpty()
            .WithMessage("Fabricante não informado");
        
    }
    
    
}