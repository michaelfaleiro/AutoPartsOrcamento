using AutoPartsOrcamento.Comunicacao.Request.StatusOrcamento;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Aplicacao.UseCase.StatusOrcamentos.Update;

public class UpdateStatusOrcamentoUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseStatusOrcamentoJson>> Execute(Guid id, UpdateStatusOrcamentoRequest request)
    {
        Validate(request);
        
        var statusOrcamento = await _dbContext.StatusOrcamentos
            .FirstOrDefaultAsync(x => x.Id == id);

        if (statusOrcamento == null)
        {
            throw new Exception("Status do orçamento não encontrado");
        }

        statusOrcamento.Nome = request.Nome;
        statusOrcamento.Descricao = request.Descricao;
        statusOrcamento.Ativo = request.Ativo;
        statusOrcamento.UpdatedAt = DateTime.UtcNow;
        
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
    
    private void Validate(UpdateStatusOrcamentoRequest request)
    {
        var validator = new UpdateStatusOrcamentoValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidateException(errors);
        }
    }
}