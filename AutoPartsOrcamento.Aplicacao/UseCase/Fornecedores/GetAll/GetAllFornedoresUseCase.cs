using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.GetAll;

public class GetAllFornedoresUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<PagedResponse<ResponseFornecedorJson>> Execute(int pageNumber, int pageSize)
    {
        var query = _dbContext.Fornecedores
                .AsNoTracking()
                .OrderBy(fornecedor => fornecedor.NomeFantasia);

        var fornecedores = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        var count = query.Count();

        return new PagedResponse<ResponseFornecedorJson>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            Data = fornecedores.Select(fornecedor => new ResponseFornecedorJson
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
            }).ToList()
        };
    }
}