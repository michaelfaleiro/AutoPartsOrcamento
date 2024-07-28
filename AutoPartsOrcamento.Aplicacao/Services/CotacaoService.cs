using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarPrecoItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarSimilar;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AlterarStatus;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetAllSimilares;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverPrecoItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverSimilar;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdatePrecoItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateSimilar;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class CotacaoService
{
    public static IServiceCollection CotacaoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterCotacaoUseCase>();
        services.AddScoped<GetAllCotacoesUseCase>();
        services.AddScoped<GetByIdCotacaoUseCase>();
        services.AddScoped<AdicionarItemCotacaoUseCase>();
        services.AddScoped<UpdateItemCotacaoUseCase>();
        services.AddScoped<RemoverItemCotacaoUseCase>();
        services.AddScoped<AdicionarPrecoItemCotacaoUseCase>();
        services.AddScoped<UpdatePrecoItemCotacaoUseCase>();
        services.AddScoped<RemoverPrecoItemCotacaoUseCase>();
        services.AddScoped<AlterarStatusCotacaoUseCase>();
        services.AddScoped<GetByIdItemCotacaoUseCase>();
        services.AddScoped<AdicionarCodigoSimilarCotacaoUseCase>();
        services.AddScoped<UpdateCodigoSimilarCotacaoUseCase>();
        services.AddScoped<RemoverCodigoSimilarCotacaoUseCase>();
        services.AddScoped<GetAllCodigoSimilaresUseCase>();

        return services;
    }

}

