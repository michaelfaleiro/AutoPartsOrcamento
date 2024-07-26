namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class CreateCotacaoRequest : Request
{
    public Guid OrcamentoId { get; set; }
    public Guid StatusId { get; set; }
}