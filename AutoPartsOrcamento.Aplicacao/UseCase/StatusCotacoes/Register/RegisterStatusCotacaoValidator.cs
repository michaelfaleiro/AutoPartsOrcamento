using AutoPartsOrcamento.Comunicacao.Request.StatusCotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Register;

public class RegisterStatusCotacaoValidator : AbstractValidator<CreateStatusCotacaoRequest>
{
    public RegisterStatusCotacaoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");
    }
    
}