using AutoPartsOrcamento.Aplicacao.UseCase.Orcamentos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Update;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.StatusOrcamento;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusOrcamentosController : ControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseStatusOrcamentoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] CreateStatusOrcamentoRequest request,
        [FromServices] RegisterStatusOrcamentoUseCase useCase)
    {
        var response = await useCase.Execute(request);
        
        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseStatusOrcamentoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllStatusOrcamentoUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, 
        int pageSize = Configuration.DefaultPageSize) 
    {
        var response = await useCase.Execute(pageNumber, pageSize);
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseStatusOrcamentoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid id,
        [FromServices] GetByIdStatusOrcamentoUseCase useCase)
    {
        var response = await useCase.Execute(id);
        
        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseStatusOrcamentoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateStatusOrcamentoRequest request,
        [FromServices] UpdateStatusOrcamentoUseCase useCase)
    {
        var response = await useCase.Execute(id, request);
        
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteStatusOrcamentoUseCase useCase)
    {
        await useCase.Execute(id);
        
        return NoContent();
    }
}
