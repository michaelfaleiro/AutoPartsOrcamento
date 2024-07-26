using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using ResponseStatusCotacaoJson = AutoPartsOrcamento.Comunicacao.Response.StatusCotacao.ResponseStatusCotacaoJson;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.GetById;

public class GetByIdStatusCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseStatusCotacaoJson>> Execute(Guid id)
    {
        var statusCotacao = await _dbContext.StatusCotacoes.FindAsync(id);

        if (statusCotacao == null)
        {
            throw new NotFoundException("Status da cotação não encontrado.");
        }

        return new Response<ResponseStatusCotacaoJson>
        {
            Data = new ResponseStatusCotacaoJson
            {
                Id = statusCotacao.Id,
                Nome = statusCotacao.Nome,
                Descricao = statusCotacao.Descricao,
                Ativo = statusCotacao.Ativo,
                CreatedAt = statusCotacao.CreatedAt,
                UpdatedAt = statusCotacao.UpdatedAt
            }
        };
    }
    
}