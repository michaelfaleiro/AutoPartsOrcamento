using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Delete;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.GetAll;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.GetById;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Register;
using AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Update;
using AutoPartsOrcamento.Comunicacao;
using AutoPartsOrcamento.Comunicacao.Request.Produto;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Produto;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateProdutoRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterProduto(
        [FromBody] CreateProdutoRequest request,
        [FromServices] RegisterProdutoUseCase useCase
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(Response<ResponseProdutoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProdutos(
        [FromServices] GetAllProdutosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize
        )
    {
        var response = await useCase.Execute(pageNumber, pageSize);
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ResponseProdutoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduto(
        [FromRoute] Guid id,
        [FromServices] GetByIdProdutoUseCase useCase
        )
    {
        var response = await useCase.Execute(id);
        
        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UpdateProdutoRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduto(
        [FromRoute] Guid id,
        [FromBody] UpdateProdutoRequest request,
        [FromServices] UpdateProdutoUseCase useCase
        )
    {
        var response = await useCase.Execute(id, request);
        
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduto(
        [FromRoute] Guid id,
        [FromServices] DeleteProdutoUseCase useCase
        )
    {
        await useCase.Execute(id);
        
        return NoContent();
    }
}