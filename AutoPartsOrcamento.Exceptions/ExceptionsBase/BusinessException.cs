using System.Net;

namespace AutoPartsOrcamento.Exceptions.ExceptionsBase;

public class BusinessException : AutoPartsOrcamentoException
{
    private readonly IList<string> _errors;

    public BusinessException(IList<string> messages) : base(string.Empty)
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