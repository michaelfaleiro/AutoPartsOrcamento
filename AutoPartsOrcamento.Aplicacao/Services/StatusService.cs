using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Update;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class StatusService
{
    public static IServiceCollection StatusUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterStatusCotacaoUseCase>();
        services.AddScoped<GetAllStatusCotacaoUseCase>();
        services.AddScoped<GetByIdStatusCotacaoUseCase>();
        services.AddScoped<DeleteStatusCotacaoUseCase>();
        services.AddScoped<UpdateStatusCotacaoUseCase>();
        
        services.AddScoped<RegisterStatusOrcamentoUseCase>();
        services.AddScoped<GetAllStatusOrcamentoUseCase>();
        services.AddScoped<GetByIdStatusOrcamentoUseCase>();
        services.AddScoped<DeleteStatusOrcamentoUseCase>();
        services.AddScoped<UpdateStatusOrcamentoUseCase>();
       

        return services;
    }
    
}