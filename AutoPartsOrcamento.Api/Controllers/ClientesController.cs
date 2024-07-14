using AutoPartsOrcamento.Aplicacao.UseCase.Clientes;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Infra;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientesController() : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> NovoCliente(
        [FromBody] CreateClienteRequest request,
        [FromServices] RegisterClienteUseCase useCase
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllClientes(
        [FromServices] GetAllClientesUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await useCase.Execute(pageNumber, pageSize);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClienteById(
        [FromRoute] Guid id,
        [FromServices] GetByIdClienteUseCase useCase)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCliente(
        [FromRoute] Guid id,
        [FromServices] DeleteClienteUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }

}
