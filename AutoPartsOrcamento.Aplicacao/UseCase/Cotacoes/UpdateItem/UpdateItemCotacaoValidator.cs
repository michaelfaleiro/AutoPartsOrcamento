using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateItem;

public class UpdateItemCotacaoValidator : AbstractValidator<UpdateItemCotacaoRequest>
{
    public UpdateItemCotacaoValidator()
    {
        RuleFor(request => request.CotacaoId)
            .NotEmpty()
            .WithMessage("O id da cotação é obrigatório");

        RuleFor(request => request.ItemId)
            .NotEmpty()
            .WithMessage("O id do item é obrigatório");

        RuleFor(request => request.Nome)
            .NotEmpty()
            .WithMessage("O nome do item é obrigatório");
        
        RuleFor(request => request.Quantidade)
            .GreaterThan(0)
            .WithMessage("A quantidade do item deve ser maior que 0");

        RuleFor(request => request.Tipo)
            .NotEmpty()
            .WithMessage("O tipo do item é obrigatório");
    }
}