using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AlterarStatus;

public class AlterarStatusValidator : AbstractValidator<AlterarStatusCotacaoRequest>
{
    public AlterarStatusValidator()
    {
        RuleFor(request => request.CotacaoId)
            .NotEmpty()
            .WithMessage("O id da cotação é obrigatório");

        RuleFor(request => request.StatusId)
            .NotEmpty()
            .WithMessage("O id do status é obrigatório");
    }
}