using AutoPartsOrcamento.Comunicacao.Request.StatusCotacao;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Update;

public class UpdateStatusCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseStatusOrcamentoJson>> Execute(Guid id, UpdateStatusCotacaoRequest request)
    {
        Validate(request);
        
        var statusCotacao = await _dbContext.StatusCotacoes
            .FirstOrDefaultAsync(x => x.Id == id);

        if (statusCotacao == null)
        {
            throw new Exception("Status da cotação não encontrado");
        }

        statusCotacao.Nome = request.Nome;
        statusCotacao.Descricao = request.Descricao;
        statusCotacao.Ativo = request.Ativo;
        statusCotacao.UpdatedAt = DateTime.UtcNow;
        
        await _dbContext.SaveChangesAsync();

        return new Response<ResponseStatusOrcamentoJson>
        {
            Data = new ResponseStatusOrcamentoJson
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
    
    private void Validate(UpdateStatusCotacaoRequest request)
    {
        var validator = new UpdateStatusCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidateException(errors);
        }
    }
}