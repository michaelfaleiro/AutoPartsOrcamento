using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarSimilar;

public class AdicionarCodigoSimilarCotacaoValidator : AbstractValidator<AdicionarCodigoSimilarCotacaoRequest>
{
    public AdicionarCodigoSimilarCotacaoValidator()
    {
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("ItemId é obrigatório");
        
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage( "Sku é obrigatório");
        
        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("Fabricante é obrigatório");
        
        RuleFor(x => x.Tipo)
            .NotEmpty()
            .WithMessage("Tipo é obrigatório");
           
    }
}