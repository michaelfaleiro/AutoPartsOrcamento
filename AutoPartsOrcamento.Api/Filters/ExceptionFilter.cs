using AutoPartsOrcamento.Comunicacao.Response;
using AutoPartsOrcamento.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoPartsOrcamento.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AutoPartsOrcamentoException)
        {
            var autoPartsOrcamentoException = (AutoPartsOrcamentoException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)autoPartsOrcamentoException.GetStatusCode();
            
            var responseJson = new ResponseErrorJson(autoPartsOrcamentoException.GetErrorMessages());

            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var list = new List<string> { "Erro interno no servidor"};

            var responseJson = new ResponseErrorJson(list);

            context.Result = new ObjectResult(responseJson);
        }
    }
}