
using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Core.Entities;
public class CodigoSimilarProduto : Entity
{
    public CotacaoItem CotacaoItem { get; set; } = null!;
    public string Sku { get;  set; } = null!;
    public string Fabricante { get;  set; } = null!;
    public ETipoCodigoSimilar Tipo { get; set; } = ETipoCodigoSimilar.Similar;

}
