using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Comunicacao.Response.Produto;

public class ResponseCodigoSimilarProdutoJson
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }  
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public ETipoCodigoSimilar Tipo { get; set; }
   
}