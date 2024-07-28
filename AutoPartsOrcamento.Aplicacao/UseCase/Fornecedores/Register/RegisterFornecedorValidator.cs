using AutoPartsOrcamento.Comunicacao.Request.Fornecedor;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Register;

public class RegisterFornecedorValidator : AbstractValidator<CreateFornecedorRequest>
{
    public RegisterFornecedorValidator()
    {
        RuleFor(x => x.RazaoSocial)
            .NotEmpty()
            .WithMessage("Razão social é obrigatória");

        RuleFor(x => x.NomeFantasia)
            .NotEmpty()
            .WithMessage("Nome fantasia é obrigatório");

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .WithMessage("CNPJ é obrigatório");

        RuleFor(x => x.Ie)
            .NotEmpty()
            .WithMessage("IE é obrigatório");

        RuleFor(x => x.Tipo)
            .IsInEnum()
            .WithMessage("Tipo de fornecedor inválido");

        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage("Telefone é obrigatório");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email é obrigatório");
    }

}