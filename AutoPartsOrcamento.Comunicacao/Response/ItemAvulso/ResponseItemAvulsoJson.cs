namespace AutoPartsOrcamento.Comunicacao.Response.ItemAvulso;

public class ResponseItemAvulsoJson
{
    public Guid Id { get; set; }
    public Guid OrcamentoId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorVenda { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}