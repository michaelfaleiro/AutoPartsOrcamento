using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.UpdateItemAvulso;

public class UpdateItemAvulsoOrcamentoValidator : AbstractValidator<UpdateItemAvulsoOrcamentoRequest>
{
    public UpdateItemAvulsoOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("ItemId é obrigatório");

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku é obrigatório");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("Fabricante é obrigatório");

        RuleFor(x => x.Quantidade)
            .GreaterThan(0)
            .WithMessage("Quantidade deve ser maior que 0");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("ValorVenda deve ser maior que 0");
    }
    
}