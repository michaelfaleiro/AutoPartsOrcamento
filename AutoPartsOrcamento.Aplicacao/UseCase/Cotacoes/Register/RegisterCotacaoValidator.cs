using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.Register;

public class RegisterCotacaoValidator : AbstractValidator<CreateCotacaoRequest>
{
    public RegisterCotacaoValidator()
    {
        RuleFor(request => request.OrcamentoId)
            .NotEmpty()
            .WithMessage("O id do orçamento é obrigatório");

        RuleFor(request => request.StatusId)
            .NotEmpty()
            .WithMessage("O id do status é obrigatório");
    }
}