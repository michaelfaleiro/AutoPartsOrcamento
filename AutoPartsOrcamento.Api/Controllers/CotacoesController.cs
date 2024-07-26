using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarPrecoItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverPrecoItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdatePrecoItem;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CotacoesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterCotacao(
        [FromBody] CreateCotacaoRequest request,
        [FromServices] RegisterCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByIdCotacao(
        [FromRoute] Guid id,
        [FromServices] GetByIdCotacaoUseCase useCase)
    {
        var cotacao = await useCase.Execute(id);

        return Ok(cotacao);
    }
    
    [HttpPost("adicionar-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarItemCotacao(
        [FromBody] AdicionarItemCotacaoRequest request,
        [FromServices] AdicionarItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpPut("update-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateItemCotacao(
        [FromBody] UpdateItemCotacaoRequest request,
        [FromServices] UpdateItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    
    [HttpDelete("remover-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoverItemCotacao(
        [FromBody] RemoverItemCotacaoRequest request,
        [FromServices] RemoverItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpPost("adicionar-preco-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarPrecoItem(
        [FromBody] AdicionarPrecoItemCotacaoRequest request,
        [FromServices] AdicionarPrecoItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpPut("update-preco-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePrecoItemCotacao(
        [FromBody] UpdatePrecoItemCotacaoRequest request,
        [FromServices] UpdatePrecoItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpDelete("remover-preco-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoverPrecoItemCotacao(
        [FromBody] RemoverPrecoItemCotacaoRequest request,
        [FromServices] RemoverPrecoItemCotacaoUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
}