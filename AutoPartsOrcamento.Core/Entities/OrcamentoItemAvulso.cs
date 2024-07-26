namespace AutoPartsOrcamento.Core.Entities;

public class OrcamentoItemAvulso : Entity
{
    public string Sku { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public int Quantidade { get; set; } 
    public decimal ValorVenda { get; set; }
    public Orcamento Orcamento { get; set; } = null!;
}