using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverItem;

public class RemoverItemCotacaoValidator : AbstractValidator<RemoverItemCotacaoRequest>
{
    public RemoverItemCotacaoValidator()
    {
        RuleFor(request => request.CotacaoId)
            .NotEmpty()
            .WithMessage("O id da cotação é obrigatório");

        RuleFor(request => request.ItemId)
            .NotEmpty()
            .WithMessage("O id do item é obrigatório");
    }
}