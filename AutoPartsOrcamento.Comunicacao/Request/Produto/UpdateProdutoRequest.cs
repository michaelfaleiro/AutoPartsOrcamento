namespace AutoPartsOrcamento.Comunicacao.Request.Produto;

public class UpdateProdutoRequest : Request
{
    public string Sku { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal ValorCusto { get;  set; }
    public decimal ValorVenda { get;  set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
}