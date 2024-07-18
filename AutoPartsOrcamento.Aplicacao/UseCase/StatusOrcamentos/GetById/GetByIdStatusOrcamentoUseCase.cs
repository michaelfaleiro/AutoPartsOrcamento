using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.GetById;

public class GetByIdStatusOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseStatusOrcamentoJson>> Execute(Guid id)
    {
        var statusOrcamento = await _dbContext.StatusOrcamentos.FindAsync(id);

        if (statusOrcamento == null)
        {
            throw new NotFoundException("Status do orçamento não encontrado.");
        }

        return new Response<ResponseStatusOrcamentoJson>
        {
            Data = [new ResponseStatusOrcamentoJson
            {
                Id = statusOrcamento.Id,
                Nome = statusOrcamento.Nome,
                Descricao = statusOrcamento.Descricao,
                Ativo = statusOrcamento.Ativo,
                CreatedAt = statusOrcamento.CreatedAt,
                UpdatedAt = statusOrcamento.UpdatedAt
            }]
        };
    }
    
}