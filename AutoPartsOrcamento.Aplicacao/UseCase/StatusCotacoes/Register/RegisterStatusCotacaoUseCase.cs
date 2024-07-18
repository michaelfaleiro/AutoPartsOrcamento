using AutoPartsOrcamento.Comunicacao.Request.StatusCotacao;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusCotacoes.Register;

public class RegisterStatusCotacaoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseStatusOrcamentoJson>> Execute(CreateStatusCotacaoRequest request)
    {
        ValidateRequest(request);
        
        var statusCotacao = new StatusCotacao
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Ativo = request.Ativo
        };

        await _dbContext.StatusCotacoes.AddAsync(statusCotacao);
        await _dbContext.SaveChangesAsync();

        return new Response<ResponseStatusOrcamentoJson>
        {
            Data = [new ResponseStatusOrcamentoJson
            {
                Id = statusCotacao.Id,
                Nome = statusCotacao.Nome,
                Descricao = statusCotacao.Descricao,
                Ativo = statusCotacao.Ativo,
                CreatedAt = statusCotacao.CreatedAt,
                UpdatedAt = statusCotacao.UpdatedAt
            }]
        };
    }
    
    private void ValidateRequest(CreateStatusCotacaoRequest request)
    {
        var validator = new RegisterStatusCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidateException(errors);
        }
    }
    
}

