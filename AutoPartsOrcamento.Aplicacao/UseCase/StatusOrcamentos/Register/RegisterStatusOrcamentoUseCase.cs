using AutoPartsOrcamento.Comunicacao.Request.StatusOrcamento;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Register;

public class RegisterStatusOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<Response<ResponseStatusOrcamentoJson>> Execute(CreateStatusOrcamentoRequest request)
    {
        ValidateRequest(request);
        
        var statusOrcamento = new StatusOrcamento
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Ativo = request.Ativo
        };

        await _dbContext.StatusOrcamentos.AddAsync(statusOrcamento);
        await _dbContext.SaveChangesAsync();

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
    
    private void ValidateRequest(CreateStatusOrcamentoRequest request)
    {
        var validator = new RegisterStatusOrcamentoValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidateException(errors);
        }
    }
    
}

