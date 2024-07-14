using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Veiculos.Update;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Veiculo;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseVeiculoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> NovoVeiculo(
        [FromBody] CreateVeiculoRequest request,
        [FromServices] RegisterVeiculoUseCase useCase
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseVeiculoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllVeiculos(
        [FromServices] GetAllVeiculosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await useCase.Execute(pageNumber, pageSize);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseVeiculoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVeiculoById(
        [FromRoute] Guid id,
        [FromServices] GetByIdVeiculoUseCase useCase)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseVeiculoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVeiculo(
        [FromRoute] Guid id,
        [FromBody] UpdateVeiculoRequest request,
        [FromServices] UpdateVeiculoUseCase useCase)
    {
        var response = await useCase.Execute(id, request);

        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVeiculo(
        [FromRoute] Guid id,
        [FromServices] DeleteVeiculoUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
