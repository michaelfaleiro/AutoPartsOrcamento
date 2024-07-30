using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverPrecoItem;

public class RemoverPrecoItemCotacaoValidator : AbstractValidator<RemoverPrecoItemCotacaoRequest>
{
    public RemoverPrecoItemCotacaoValidator()
    {
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item não informado");

        RuleFor(x => x.PrecoItemId)
            .NotEmpty()
            .WithMessage("PrecoItemId não informado");
    }
    
}