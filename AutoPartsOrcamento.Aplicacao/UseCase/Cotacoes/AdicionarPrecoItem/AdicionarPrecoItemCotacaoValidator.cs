using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarPrecoItem;

public class AdicionarPrecoItemCotacaoValidator : AbstractValidator<AdicionarPrecoItemCotacaoRequest>
{
    
    public AdicionarPrecoItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty()
            .WithMessage("Cotação não informada");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item não informado");

        RuleFor(x => x.FornecedorId)
            .NotEmpty()
            .WithMessage("Fornecedor não informado");

        RuleFor(x => x.QuantidadeAtendida)
            .GreaterThan(0)
            .WithMessage("Quantidade atendida deve ser maior que zero");

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("SKU não informado");

        RuleFor(x => x.ValorCusto)
            .GreaterThan(0)
            .WithMessage("Valor de custo deve ser maior que zero");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("Valor de venda deve ser maior que zero");

        RuleFor(x => x.PrazoExpedicao)
            .GreaterThan(0)
            .WithMessage("Prazo de expedição deve ser maior que zero");
    }
}