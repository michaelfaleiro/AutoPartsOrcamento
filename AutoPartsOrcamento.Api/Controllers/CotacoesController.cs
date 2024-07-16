using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.AdicionarItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.RemoverItem;
using AutoPartsOrcamento.Aplicacao.UseCase.Cotacoes.UpdateItem;
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
    
}