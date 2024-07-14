namespace AutoPartsOrcamento.Comunicacao.Request.Orcamento;

public class CreateOrcamentoRequest : Request
{
    public Guid ClienteId { get; set; }
    public Guid VeiculoId { get; set; }
}