using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateSimilar;

public class UpdateCodigoSimilarCotacaoValidator : AbstractValidator<UpdateCodigoSimilarCotacaoRequest>
{
    public UpdateCodigoSimilarCotacaoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id é obrigatório");
        
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