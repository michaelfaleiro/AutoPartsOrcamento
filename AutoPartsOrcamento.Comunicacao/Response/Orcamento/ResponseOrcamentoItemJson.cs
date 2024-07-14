namespace AutoPartsOrcamento.Comunicacao.Response.Orcamento;

public class ResponseOrcamentoItemJson
{
    public Guid Id { get; set; }
    public Guid OrcamentoId { get; set; } 
    public Guid ProdutoId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public int Quantidade { get; set; } 
    public decimal ValorUnitario { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}