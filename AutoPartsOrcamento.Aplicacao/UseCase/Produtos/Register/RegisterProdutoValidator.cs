using AutoPartsOrcamento.Comunicacao.Request.Produto;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Register;

public class RegisterProdutoValidator : AbstractValidator<CreateProdutoRequest>
{
    public RegisterProdutoValidator()
    {
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("SKU é obrigatório");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("Fabricante é obrigatório");

        RuleFor(x => x.ValorCusto)
            .GreaterThan(0)
            .WithMessage("Valor de custo é obrigatório");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("Valor de venda é obrigatório");
    }
    
}