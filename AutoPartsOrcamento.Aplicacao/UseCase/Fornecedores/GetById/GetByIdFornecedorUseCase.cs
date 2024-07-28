using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.GetById;

public class GetByIdFornecedorUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseFornecedorJson>> Execute(Guid id)
    {
        var fornecedor = await _dbContext.Fornecedores
            .AsNoTracking()
            .FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

        if (fornecedor is null)
            throw new NotFoundException("Fornecedor não encontrado");

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