using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Delete;

public class DeleteFornecedorUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task Execute(Guid id)
    {
        var fornecedor = await _dbContext.Fornecedores
            .FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

        if (fornecedor is null)
            throw new NotFoundException("Fornecedor não encontrado");

        _dbContext.Fornecedores.Remove(fornecedor);

        await _dbContext.SaveChangesAsync();
    }

}