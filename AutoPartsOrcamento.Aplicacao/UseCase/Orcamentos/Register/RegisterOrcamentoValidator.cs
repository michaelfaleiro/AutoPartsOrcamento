using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using FluentValidation;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Register;

public class RegisterOrcamentoValidator : AbstractValidator<CreateOrcamentoRequest>
{
    public RegisterOrcamentoValidator()
    {
        RuleFor(request => request.ClienteId)
            .NotEmpty()
            .WithMessage("O id do cliente é obrigatório");

        RuleFor(request => request.VeiculoId)
            .NotEmpty()
            .WithMessage("O id do veículo é obrigatório");

        RuleFor(request => request.StatusId)
            .NotEmpty()
            .WithMessage("O id do status é obrigatório");
    }
    
}