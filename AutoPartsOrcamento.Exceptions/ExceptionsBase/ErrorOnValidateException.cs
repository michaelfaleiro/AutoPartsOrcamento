using System.Net;

namespace AutoPartsOrcamento.Exceptions.ExceptionsBase;

public class ErrorOnValidateException : AutoPartsOrcamentoException
{
    private readonly IList<string> _errors;

    public ErrorOnValidateException(IList<string> messages) : base(string.Empty)
    {
        _errors = messages;
    }

    public override IList<string> GetErrorMessages()
    {
        return _errors;
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
}