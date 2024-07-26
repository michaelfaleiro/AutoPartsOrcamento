namespace AutoPartsOrcamento.Comunicacao.Request.Orcamento;

public class UpdateItemAvulsoOrcamentoRequest : Request
{
    public Guid OrcamentoId { get; set; }
    public Guid ItemId { get; set; }
    public string Sku { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Fabricante { get; set; } = null!;
    public int Quantidade { get; set; } 
    public decimal ValorVenda { get; set; }
    
}