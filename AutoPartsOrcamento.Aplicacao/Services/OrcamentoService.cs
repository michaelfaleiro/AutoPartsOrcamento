using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.AdicionarItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.AdicionarItemAvulso;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.RemoverItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.RemoverItemAvulso;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.UpdateItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.UpdateItemAvulso;
using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
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
        services.AddScoped<AdicionarItemOrcamentoUseCase>();
        services.AddScoped<UpdateItemOrcamentoUseCase>();
        services.AddScoped<RemoverItemOrcamentoUseCase>();
        services.AddScoped<AdicionarItemAvulsoOrcamentoUseCase>();
        services.AddScoped<UpdateItemAvulsoOrcamentoUseCase>();
        services.AddScoped<RemoverItemAvulsoOrcamentoUseCase>();

        return services;
    }
    
}