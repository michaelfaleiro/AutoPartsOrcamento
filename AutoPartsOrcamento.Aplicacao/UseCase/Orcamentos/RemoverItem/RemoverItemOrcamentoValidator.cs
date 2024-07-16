using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.RemoverItem;

public class RemoverItemOrcamentoValidator : AbstractValidator<RemoverItemOrcamentoRequest>
{
    public RemoverItemOrcamentoValidator()
    {
        RuleFor(request => request.OrcamentoId)
            .NotEmpty()
            .WithMessage("O Id do orçamento é obrigatório");

        RuleFor(request => request.ItemId)
            .NotEmpty()
            .WithMessage("O Id do item é obrigatório");
    }
}