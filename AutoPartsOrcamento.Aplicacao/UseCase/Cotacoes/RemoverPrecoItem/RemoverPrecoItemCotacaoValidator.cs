using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverPrecoItem;

public class RemoverPrecoItemCotacaoValidator : AbstractValidator<RemoverPrecoItemCotacaoRequest>
{
    public RemoverPrecoItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty()
            .WithMessage("Cotação não informada");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item não informado");
    }
    
}