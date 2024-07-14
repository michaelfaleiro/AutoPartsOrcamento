using System.Net;

namespace AutoPartsOrcamento.Exceptions.ExceptionsBase;

public class ErrorOnSaveException(string message) : AutoPartsOrcamentoException(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.InternalServerError;
    }

    public override IList<string> GetErrorMessages()
    {
        return [message];
    }
}