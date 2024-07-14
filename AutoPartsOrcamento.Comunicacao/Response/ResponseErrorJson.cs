namespace AutoPartsOrcamento.Comunicacao.Response;

public class ResponseErrorJson
{
    public IList<string> Errors { get; set; } = [];

    public ResponseErrorJson(IList<string> errors)
    {
        Errors = errors;
    }

}