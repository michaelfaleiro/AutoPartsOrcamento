using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Update;
using AutoPartsOrcamento.Comunicacao.Request.StatusCotacao;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusCotacao;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusCotacoesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseStatusCotacaoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(
        [FromBody] CreateStatusCotacaoRequest request,
        [FromServices] RegisterStatusCotacaoUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseStatusCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(
        [FromServices] GetAllStatusCotacaoUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseStatusCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(
        [FromRoute] Guid id,
        [FromServices] GetByIdStatusCotacaoUseCase useCase)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseStatusCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(
        [FromRoute] Guid id,
        [FromBody] UpdateStatusCotacaoRequest request,
        [FromServices] UpdateStatusCotacaoUseCase useCase)
    {
        var response = await useCase.Execute(id, request);
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteStatusCotacaoUseCase useCase)
    {
        await useCase.Execute(id);
        return NoContent();
    }
    
}