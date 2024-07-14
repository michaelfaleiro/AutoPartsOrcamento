using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;

public class RegisterClienteValidator : AbstractValidator<CreateClienteRequest>
{
    public RegisterClienteValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Email inválido");
    
    }
    
}