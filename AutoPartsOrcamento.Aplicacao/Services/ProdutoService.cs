using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Search;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsOrcamento.Aplicacao.Services;

public static class ProdutoService
{
    public static IServiceCollection ProdutoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterProdutoUseCase>();
        services.AddScoped<GetAllProdutosUseCase>();
        services.AddScoped<GetByIdProdutoUseCase>();
        services.AddScoped<UpdateProdutoUseCase>();
        services.AddScoped<DeleteProdutoUseCase>();
        services.AddScoped<SearchProdutoBySkuNomeUseCase>();

        return services;
    }
}