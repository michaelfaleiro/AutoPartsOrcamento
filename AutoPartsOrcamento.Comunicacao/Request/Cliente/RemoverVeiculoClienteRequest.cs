namespace AutoPartsOrcamento.Comunicacao.Request.Cliente;

public class RemoverVeiculoClienteRequest : Request
{
    public Guid ClienteId { get; set; }
    public Guid VeiculoId { get; set; }
}