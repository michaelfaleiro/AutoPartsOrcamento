using AutoPartsOrcamento.Aplicacao.UseCase.Clientes;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.AdicionarVeiculoCliente;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.RemoverVeiculoCliente;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Search;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Update;
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
        services.AddScoped<UpdateClienteUseCase>();
        services.AddScoped<AdicionarVeiculoClienteUseCase>();
        services.AddScoped<RemoverVeiculoClienteUseCase>();
        services.AddScoped<SearchClienteByNomeTelefoneVeiculoUseCase>();

        return services;
    }
}
