using System.Net;

namespace AutoPartsOrcamento.Exceptions.ExceptionsBase;

public class NotFoundException(string message) : AutoPartsOrcamentoException(message)
{
    public override IList<string> GetErrorMessages()
    {
        return [Message];
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }
}