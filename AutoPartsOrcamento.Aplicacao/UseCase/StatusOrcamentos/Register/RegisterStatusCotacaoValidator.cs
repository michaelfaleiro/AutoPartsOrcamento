using AutoPartsOrcamento.Comunicacao.Request.StatusOrcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Register;

public class RegisterStatusOrcamentoValidator : AbstractValidator<CreateStatusOrcamentoRequest>
{
    public RegisterStatusOrcamentoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");
    }
    
}