
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Update;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Fornecedor;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Fornecedores : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseFornecedorJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterFornecedor(
        [FromBody] CreateFornecedorRequest request,
        [FromServices] RegisterFornecedorUseCase useCase)
    {
        var fornecedor = await useCase.Execute(request);

        return Ok(fornecedor);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseFornecedorJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFornecedores(
        [FromServices] GetAllFornedoresUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize
        )
    {
        var fornecedores = await useCase.Execute(pageNumber, pageSize);

        return Ok(fornecedores);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseFornecedorJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByIdFornecedor(
        [FromRoute] Guid id,
        [FromServices] GetByIdFornecedorUseCase useCase)
    {
        var fornecedor = await useCase.Execute(id);

        return Ok(fornecedor);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<ResponseFornecedorJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateFornecedor(
        [FromRoute] Guid id,
        [FromBody] UpdateFornecedorRequest request,
        [FromServices] UpdateFornecedorUseCase useCase)
    {
        var fornecedor = await useCase.Execute(id, request);

        return Ok(fornecedor);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFornecedor(
        [FromRoute] Guid id,
        [FromServices] DeleteFornecedorUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}