using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.RemoverItemAvulso;

public class RemoverItemAvulsoValidator : AbstractValidator<RemoverItemAvulsoOrcamentoRequest>
{
        public RemoverItemAvulsoValidator()
        {
            RuleFor(x => x.OrcamentoId)
                .NotEmpty()
                .WithMessage("O Id do orçamento é obrigatório");
    
            RuleFor(x => x.ItemId)
                .NotEmpty()
                .WithMessage("O Id do item é obrigatório");
        }
}