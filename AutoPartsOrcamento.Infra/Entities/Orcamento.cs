namespace AutoPartsOrcamento.Infra.Entities;
public class Orcamento : Entity
{
     
    public Cliente Cliente { get; set; } = null!;
    public IList<OrcamentoItem> OrcamentoItems { get;  set; } = [];
    public IList<Cotacao> Cotacoes { get; set; } = [];
}
