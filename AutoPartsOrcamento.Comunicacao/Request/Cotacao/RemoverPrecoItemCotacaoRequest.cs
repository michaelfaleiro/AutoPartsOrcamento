namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class RemoverPrecoItemCotacaoRequest : Request
{
    public Guid ItemId { get; set; }
    public Guid PrecoItemId { get; set; }
}