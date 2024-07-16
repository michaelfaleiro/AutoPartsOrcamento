namespace AutoPartsOrcamento.Comunicacao.Request.Orcamento;

public class RemoverItemOrcamentoRequest : Request
{
    public Guid OrcamentoId { get; set; }
    public Guid ItemId { get; set; }
}