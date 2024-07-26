namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class RemoverPrecoItemCotacaoRequest : Request
{
    public Guid CotacaoId { get; set; }
    public Guid ItemId { get; set; }
}