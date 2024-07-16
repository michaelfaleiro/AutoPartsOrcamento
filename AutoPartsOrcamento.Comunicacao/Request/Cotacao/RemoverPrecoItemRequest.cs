namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class RemoverPrecoItemRequest : Request
{
    public Guid CotacaoId { get; set; }
    public Guid ItemId { get; set; }
}