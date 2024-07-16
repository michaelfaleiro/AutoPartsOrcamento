namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class RemoverItemCotacaoRequest : Request
{
    public Guid CotacaoId { get; set; }
    public Guid ItemId { get; set; }
}