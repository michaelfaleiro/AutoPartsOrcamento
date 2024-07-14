namespace AutoPartsOrcamento.Comunicacao.Request.Cliente;

public class AdicionarVeiculoClienteRequest : Request
{
    public Guid ClienteId { get; set; }
    public Guid VeiculoId { get; set; }
    
}