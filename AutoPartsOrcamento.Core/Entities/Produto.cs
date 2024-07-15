
namespace AutoPartsOrcamento.Core.Entities;
public class Produto : Entity
{
    public string Sku { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Fabricante { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal ValorCusto { get;  set; }
    public decimal ValorVenda { get;  set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    public IList<CodigoSimilarProduto> CodigoSimilares { get; set; } = [];

}
