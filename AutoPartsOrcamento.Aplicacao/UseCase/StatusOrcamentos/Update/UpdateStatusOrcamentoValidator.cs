using AutoPartsOrcamento.Comunicacao.Request.StatusOrcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Update;

public class UpdateStatusOrcamentoValidator : AbstractValidator<UpdateStatusOrcamentoRequest>
{
    public UpdateStatusOrcamentoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");
    }
    
}