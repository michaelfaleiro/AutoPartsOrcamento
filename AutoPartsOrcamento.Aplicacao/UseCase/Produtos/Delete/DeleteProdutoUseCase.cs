using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Produtos.Delete;

public class DeleteProdutoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task Execute(Guid id)
    {
        var produto = await _dbContext.Produtos.FindAsync(id);

        if (produto == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }

        _dbContext.Produtos.Remove(produto);
        await _dbContext.SaveChangesAsync();
        
    }
    
}