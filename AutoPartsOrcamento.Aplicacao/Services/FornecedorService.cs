using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Update;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class FornecedorService
{

    public static IServiceCollection FornecedorUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterFornecedorUseCase>();
        services.AddScoped<GetAllFornedoresUseCase>();
        services.AddScoped<GetByIdFornecedorUseCase>();
        services.AddScoped<DeleteFornecedorUseCase>();
        services.AddScoped<UpdateFornecedorUseCase>();

        return services;
    }
}