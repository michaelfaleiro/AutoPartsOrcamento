using AutoPartsOrcamento.Aplicacao.UseCase.Clientes;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class ClienteService
{
    public static IServiceCollection ClienteUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterClienteUseCase>();
        services.AddScoped<GetAllClientesUseCase>();
        services.AddScoped<GetByIdClienteUseCase>();
        services.AddScoped<DeleteClienteUseCase>();

        return services;
    }
}
