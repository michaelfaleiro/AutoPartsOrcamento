using AutoPartsOrcamento.Comunicacao.Request.Fornecedor;
using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;
using AutoPartsOrcamento.Core.Entities;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using AutoPartsOrcamento.Infra;

namespace AutoPartsOrcamento.Aplicacao.UseCase.Fornecedores.Register;

public class RegisterFornecedorUseCase(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<Response<ResponseFornecedorJson>> Execute(CreateFornecedorRequest request)
    {
        Validate(request);

        var fornecedor = new Fornecedor
        {
            RazaoSocial = request.RazaoSocial,
            NomeFantasia = request.NomeFantasia,
            Cnpj = request.Cnpj,
            Ie = request.Ie,
            Tipo = request.Tipo,
            Telefone = request.Telefone,
            Email = request.Email
        };

        await _dbContext.Fornecedores.AddAsync(fornecedor);
        await _dbContext.SaveChangesAsync();

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

    private void Validate(CreateFornecedorRequest request)
    {
        var validator = new RegisterFornecedorValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid is true) return;
        var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }

}