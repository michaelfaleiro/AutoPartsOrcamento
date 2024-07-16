namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class UpdatePrecoItemRequest : Request
{
    public Guid CotacaoId { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid Sku { get; set; } 
    public decimal Preco { get; set; }
}