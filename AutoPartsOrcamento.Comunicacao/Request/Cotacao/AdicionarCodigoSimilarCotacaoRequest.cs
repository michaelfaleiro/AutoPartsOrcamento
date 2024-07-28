using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class AdicionarCodigoSimilarCotacaoRequest : Request
{
    public Guid ItemId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public ETipoCodigoSimilar Tipo { get; set; }
    
}