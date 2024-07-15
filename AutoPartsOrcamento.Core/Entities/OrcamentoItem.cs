
namespace AutoPartsOrcamento.Core.Entities;
public class OrcamentoItem : Entity
{
    public Guid OrcamentoId { get;  set; } 
    public Orcamento Orcamento { get;  set; } = null!;
    public Guid ProdutoId { get;  set; }
    public Produto Produto { get;  set; } = null!;
    public int Quantidade { get;  set; }
    public decimal ValorUnitario { get;  set; }
}
