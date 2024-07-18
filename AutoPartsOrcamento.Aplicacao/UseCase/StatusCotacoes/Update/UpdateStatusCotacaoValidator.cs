using AutoPartsOrcamento.Comunicacao.Request.StatusCotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Update;

public class UpdateStatusCotacaoValidator : AbstractValidator<UpdateStatusCotacaoRequest>
{
    public UpdateStatusCotacaoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");
    }
    
}