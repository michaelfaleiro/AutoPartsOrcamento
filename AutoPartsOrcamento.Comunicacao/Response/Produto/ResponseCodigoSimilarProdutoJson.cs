namespace AutoPartsOrcamento.Comunicacao.Response.Produto;

public class ResponseCodigoSimilarProdutoJson
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}