namespace AutoPartsOrcamento.Infra.Entities;
public class Cotacao : Entity
{
        
    public Orcamento Orcamento { get; set; } = null!;
    public IList<CotacaoItem> CotacaoItems { get; set; } = [];
    public string Status { get; set; } = string.Empty;
}
