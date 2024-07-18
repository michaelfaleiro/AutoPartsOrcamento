using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.AdicionarVeiculoCliente;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.RemoverVeiculoCliente;
using AutoPartsOrcamento.Aplicacao.UseCase.Clientes.Update;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Cliente;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    [ProducesResponseType(typeof(Response<ResponseClienteComVeiculosJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClienteById(
        [FromRoute] Guid id,
        [FromServices] GetByIdClienteUseCase useCase)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCliente(
        [FromRoute] Guid id,
        [FromBody] UpdateClienteRequest request,
        [FromServices] UpdateClienteUseCase useCase)
    {
        request.Id = id;
        
        var response = await useCase.Execute(request);

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
    
    [HttpPost("adicionar-veiculo")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarVeiculoCliente(
        [FromBody] AdicionarVeiculoClienteRequest request,
        [FromServices] AdicionarVeiculoClienteUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    
    [HttpDelete("remover-veiculo")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverVeiculoCliente(
        [FromBody] RemoverVeiculoClienteRequest request,
        [FromServices] RemoverVeiculoClienteUseCase useCase)
    {
        await useCase.Execute(request);

        return NoContent();
    }

}
