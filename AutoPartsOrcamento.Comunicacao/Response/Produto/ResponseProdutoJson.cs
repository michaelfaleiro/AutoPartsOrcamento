namespace AutoPartsOrcamento.Comunicacao.Response.Produto;

public class ResponseProdutoJson 
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal ValorCusto { get;  set; }
    public decimal ValorVenda { get;  set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    // public IList<CodigoSimilarProduto> CodigoSimilares { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}