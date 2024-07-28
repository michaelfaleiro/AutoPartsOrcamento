namespace AutoPartsOrcamento.Comunicacao.Request.Produto;

public class SearchProdutoRequest : Request
{
    public string Query { get; set; } = string.Empty;
}