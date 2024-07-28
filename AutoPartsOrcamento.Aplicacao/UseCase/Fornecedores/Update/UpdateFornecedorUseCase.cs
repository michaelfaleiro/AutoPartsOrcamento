
using AutoPartsOrcamento.Comunicacao.Request.Fornecedor;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Update;

public class UpdateFornecedorUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseFornecedorJson>> Execute(Guid id, UpdateFornecedorRequest request)
    {
        var fornecedor = await _dbContext.Fornecedores
            .FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

        if (fornecedor is null)
            throw new NotFoundException("Fornecedor não encontrado");

        fornecedor.RazaoSocial = request.RazaoSocial;
        fornecedor.NomeFantasia = request.NomeFantasia;
        fornecedor.Cnpj = request.Cnpj;
        fornecedor.Ie = request.Ie;
        fornecedor.Tipo = request.Tipo;
        fornecedor.Telefone = request.Telefone;
        fornecedor.Email = request.Email;
        fornecedor.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new Response<ResponseFornecedorJson>
        {
            Data = new ResponseFornecedorJson
            {
                Id = fornecedor.Id,
                RazaoSocial = fornecedor.RazaoSocial,
                NomeFantasia = fornecedor.NomeFantasia,
                Cnpj = fornecedor.Cnpj,
                Ie = fornecedor.Ie,
                Tipo = fornecedor.Tipo,
                Telefone = fornecedor.Telefone,
                Email = fornecedor.Email,
                CreatedAt = fornecedor.CreatedAt,
                UpdatedAt = fornecedor.UpdatedAt
            }
        };
    }
}