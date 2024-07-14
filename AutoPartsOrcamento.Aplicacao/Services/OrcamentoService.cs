using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Register;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class OrcamentoService
{
    public static IServiceCollection OrcamentoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterOrcamentoUseCase>();
        services.AddScoped<GetAllOrcamentosUseCase>();
        services.AddScoped<GetByIdOrcamentoUseCase>();
        services.AddScoped<DeleteOrcamentoUseCase>();
        // services.AddScoped<AdicionarItemOrcamentoUseCase>();
        // services.AddScoped<RemoverItemOrcamentoUseCase>();

        return services;
    }
    
}