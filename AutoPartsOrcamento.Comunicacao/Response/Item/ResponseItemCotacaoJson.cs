using AutoPartsOrcamento.Comunicacao.Response.Produto;
using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Comunicacao.Response.Item;

public class ResponseItemCotacaoJson
{
    public Guid Id { get; set; }
    public int Quantidade { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public ETipoProduto Tipo { get; set; }
    public IList<ResponseCodigoSimilarProdutoJson> CodigoSimilares { get; set; } = [];
    public IList<ResponsePrecoItemCotacaoJson> PrecoItemCotacoes { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}