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
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Orcamento;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Orcamento;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrcamentosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseOrcamentoJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseOrcamentoJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(
        [FromBody] CreateOrcamentoRequest request,
        [FromServices] RegisterOrcamentoUseCase useCase
        )
    {
        var response = await useCase.Execute(request);
        
        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ResponseOrcamentoJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(
        [FromServices] GetAllOrcamentosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await useCase.Execute(pageNumber, pageSize);
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ResponseOrcamentoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid id,
        [FromServices] GetByIdOrcamentoUseCase useCase)
    {
        var response = await useCase.Execute(id);
        
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteOrcamentoUseCase useCase)
    {
        await useCase.Execute(id);
        
        return NoContent();
    }
    
    [HttpPost("adicionar-item")]
    [ProducesResponseType( StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostItem(
        [FromBody] AdicionarItemOrcamentoRequest request,
        [FromServices] AdicionarItemOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        
        return NoContent();
    }
    
    [HttpPut("atualizar-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutItem(
        [FromBody] UpdateItemOrcamentoRequest request,
        [FromServices] UpdateItemOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        
        return NoContent();
    }
    
    [HttpDelete("remover-item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItem(
        [FromBody] RemoverItemOrcamentoRequest request,
        [FromServices] RemoverItemOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        
        return NoContent();
    }
    
    [HttpPost("adicionar-item-avulso")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostItemAvulso(
        [FromBody] AdicionarItemAvulsoOrcamentoRequest request,
        [FromServices] AdicionarItemAvulsoOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        
        return NoContent();
    }
    
    [HttpPut("atualizar-item-avulso")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutItemAvulso(
        [FromBody] UpdateItemAvulsoOrcamentoRequest request,
        [FromServices] UpdateItemAvulsoOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        
        return NoContent();
    }
    
    [HttpDelete("remover-item-avulso")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItemAvulso(
        [FromBody] RemoverItemAvulsoOrcamentoRequest request,
        [FromServices] RemoverItemAvulsoOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        
        return NoContent();
    }
    
}