using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Request.Veiculo;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Register;

public class RegisterVeiculoValidator : AbstractValidator<CreateVeiculoRequest>
{
    public RegisterVeiculoValidator()
    {
        RuleFor(x => x.Marca)
            .NotEmpty()
            .WithMessage("Marca é obrigatória.");

        RuleFor(x => x.Modelo)
            .NotEmpty()
            .WithMessage("Modelo é obrigatório.");

        RuleFor(x => x.Ano)
            .NotEmpty()
            .WithMessage("Ano é obrigatório.");

        RuleFor(x => x.Placa)
            .Must(placa => string.IsNullOrEmpty(placa) || placa.Length == 7)
            .WithMessage("Placa deve ter 7 dígitos.");

        RuleFor(x => x.Chassi)
            .Must(chassi => string.IsNullOrEmpty(chassi) || chassi.Length == 17)
            .WithMessage("Chassi deve ter 17 dígitos.");
        
    }
}