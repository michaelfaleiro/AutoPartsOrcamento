namespace AutoPartsOrcamento.Comunicacao.Request.Orcamento;

public class AdicionarItemAvulsoOrcamentoRequest : Request
{
    public Guid OrcamentoId { get; set; }
    public string Sku { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Fabricante { get; set; } = null!;
    public int Quantidade { get; set; } 
    public decimal ValorVenda { get; set; }
}