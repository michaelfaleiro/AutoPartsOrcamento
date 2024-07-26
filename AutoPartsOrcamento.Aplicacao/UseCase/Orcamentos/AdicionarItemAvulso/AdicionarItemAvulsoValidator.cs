using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.AdicionarItemAvulso;

public class AdicionarItemAvulsoValidator : AbstractValidator<AdicionarItemAvulsoOrcamentoRequest>
{
    
    public AdicionarItemAvulsoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("O Id do orçamento é obrigatório");

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("O SKU é obrigatório");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O Nome é obrigatório");

        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("O Fabricante é obrigatório");

        RuleFor(x => x.Quantidade)
            .GreaterThan(0)
            .WithMessage("A Quantidade deve ser maior que 0");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("O Valor de venda deve ser maior que 0");
    }
    
}