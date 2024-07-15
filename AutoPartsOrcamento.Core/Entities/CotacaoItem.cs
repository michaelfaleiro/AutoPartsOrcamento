using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Core.Entities;
public class CotacaoItem : Entity
{
        
    public Cotacao Cotacao { get; set; } = null!;
    public int Quantidade { get;  set; }
    public string Nome { get;  set; } = null!;
    public string Sku { get;  set; } = string.Empty;
    public ETipoProduto Tipo { get;  set; } = ETipoProduto.PontaEstoque;
    public IList<PrecoItemCotacao> PrecoItemCotacoes { get;  set; } = [];
    public IList<CodigoSimilarProduto> CodigoSimilares { get;  set; } = [];
    

}
