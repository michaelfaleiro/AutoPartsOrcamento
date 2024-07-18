
namespace AutoPartsOrcamento.Core.Entities;
public class Orcamento : Entity
{
    public Cliente Cliente { get; set; } = null!;
    public Veiculo Veiculo { get; set; } = null!;
    public IList<OrcamentoItem> OrcamentoItems { get;  set; } = [];
    public IList<Cotacao> Cotacoes { get; set; } = [];
    public StatusOrcamento Status { get; set; } = null!;
}
