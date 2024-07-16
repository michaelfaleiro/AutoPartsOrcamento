using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.UpdateItem;

public class UpdateItemOrcamentoValidator : AbstractValidator<UpdateItemOrcamentoRequest>
{
    public UpdateItemOrcamentoValidator()
    {
        RuleFor(request => request.OrcamentoId)
            .NotEmpty()
            .WithMessage("O Id do orçamento é obrigatório");

        RuleFor(request => request.ProdutoId)
            .NotEmpty()
            .WithMessage("O Id do produto é obrigatório");

        RuleFor(request => request.Quantidade)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que zero");

        RuleFor(request => request.ValorUnitario)
            .GreaterThan(0)
            .WithMessage("O valor unitário deve ser maior que zero");
    }
    
}