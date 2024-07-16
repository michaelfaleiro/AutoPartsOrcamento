using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class UpdateItemCotacaoRequest : Request
{
    public Guid CotacaoId { get; set; }
    public Guid ItemId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public ETipoProduto Tipo { get; set; }
}