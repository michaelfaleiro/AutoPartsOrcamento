using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateItem;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class CotacaoService
{
    public static IServiceCollection CotacaoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterCotacaoUseCase>();
        // services.AddScoped<GetAllCotacoesUseCase>();
        services.AddScoped<GetByIdCotacaoUseCase>();
        // services.AddScoped<DeleteCotacaoUseCase>();
        // services.AddScoped<UpdateCotacaoUseCase>();
        services.AddScoped<AdicionarItemCotacaoUseCase>();
        services.AddScoped<UpdateItemCotacaoUseCase>();
        services.AddScoped<RemoverItemCotacaoUseCase>();

        return services;
    }
    
}