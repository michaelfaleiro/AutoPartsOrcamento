namespace AutoPartsOrcamento.Core.Entities;
public class ClienteVeiculo : Entity
{

    public Guid ClienteId { get; set; }
    public Cliente Cliente { get;set; } = null!;
    public Guid VeiculoId { get;set; } 
    public Veiculo Veiculo { get;set; } = null!;
}
