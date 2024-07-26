namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class AlterarStatusCotacaoRequest : Request
{
    public Guid CotacaoId { get; set; }
    public Guid StatusId { get; set; } 
}