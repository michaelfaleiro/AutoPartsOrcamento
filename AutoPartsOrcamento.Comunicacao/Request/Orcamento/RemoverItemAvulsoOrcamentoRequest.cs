namespace AutoPartsOrcamento.Comunicacao.Request.Orcamento;

public class RemoverItemAvulsoOrcamentoRequest : Request
{
    public Guid OrcamentoId { get; set; }
    public Guid ItemId { get; set; }
}