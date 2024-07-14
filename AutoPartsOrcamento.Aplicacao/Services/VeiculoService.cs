using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class VeiculoService
{
    public static IServiceCollection VeiculoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterVeiculoUseCase>();
        services.AddScoped<GetAllVeiculosUseCase>();
        services.AddScoped<GetByIdVeiculoUseCase>();
        services.AddScoped<DeleteVeiculoUseCase>();
        services.AddScoped<UpdateVeiculoUseCase>();

        return services;
    }
    
}