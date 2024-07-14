using System.Net;

namespace AutoPartsOrcamento.Exceptions.ExceptionsBase;

public abstract class AutoPartsOrcamentoException(string message) : SystemException(message)
{
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}