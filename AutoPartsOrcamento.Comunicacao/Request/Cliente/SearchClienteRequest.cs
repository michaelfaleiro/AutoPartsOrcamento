namespace AutoPartsOrcamento.Comunicacao.Request.Cliente;

public class SearchClienteRequest : Request
{
    public string Query { get; set; } = string.Empty;

}