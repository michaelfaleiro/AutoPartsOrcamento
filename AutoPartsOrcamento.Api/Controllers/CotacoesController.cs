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
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response.Item;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CotacoesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseCotacaoIdJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterCotacao(
        [FromBody] CreateCotacaoRequest request,
        [FromServices] RegisterCotacaoUseCase useCase)
    {
        var cotacao = await useCase.Execute(request);

        return Ok(cotacao);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseCotacaoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCotacoes(
        [FromServices] GetAllCotacoesUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize
        )
    {
        var cotacoes = await useCase.Execute(pageNumber, pageSize);

        return Ok(cotacoes);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByIdCotacao(
        [FromRoute] Guid id,
        [FromServices] GetByIdCotacaoUseCase useCase)
    {
        var cotacao = await useCase.Execute(id);

        return Ok(cotacao);
    }

    [HttpPost("adicionar-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarItemCotacao(
        [FromBody] AdicionarItemCotacaoRequest request,
        [FromServices] AdicionarItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [HttpPut("update-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateItemCotacao(
        [FromBody] UpdateItemCotacaoRequest request,
        [FromServices] UpdateItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }


    [HttpDelete("remover-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoverItemCotacao(
        [FromBody] RemoverItemCotacaoRequest request,
        [FromServices] RemoverItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [HttpPost("adicionar-preco-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarPrecoItem(
        [FromBody] AdicionarPrecoItemCotacaoRequest request,
        [FromServices] AdicionarPrecoItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [HttpPut("update-preco-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePrecoItemCotacao(
        [FromBody] UpdatePrecoItemCotacaoRequest request,
        [FromServices] UpdatePrecoItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [HttpDelete("remover-preco-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoverPrecoItemCotacao(
        [FromBody] RemoverPrecoItemCotacaoRequest request,
        [FromServices] RemoverPrecoItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [HttpPut("alterar-status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AlterarStatusCotacao(
        [FromBody] AlterarStatusCotacaoRequest request,
        [FromServices] AlterarStatusCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [HttpGet("item/{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseItemCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByIdItemCotacao(
        [FromRoute] Guid id,
        [FromServices] GetByIdItemCotacaoUseCase useCase)
    {
        var item = await useCase.Execute(id);

        return Ok(item);
    }
    
    [HttpPost("similares")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarCodigoSimilarCotacao(
        [FromBody] AdicionarCodigoSimilarCotacaoRequest request,
        [FromServices] AdicionarCodigoSimilarCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpGet("similares/{itemId:guid}")]
    [ProducesResponseType(typeof(Response<ResponseCodigoSimilarProdutoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCodigoSimilares(
        [FromRoute] Guid itemId,
        [FromServices] GetAllCodigoSimilaresUseCase useCase)
    {
        var similares = await useCase.Execute(itemId);

        return Ok(similares);
    }
    
    [HttpPut("similares")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCodigoSimilarCotacao(
        [FromBody] UpdateCodigoSimilarCotacaoRequest request,
        [FromServices] UpdateCodigoSimilarCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpDelete("similares/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoverCodigoSimilarCotacao(
        [FromRoute] Guid id,
        [FromServices] RemoverCodigoSimilarCotacaoUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}