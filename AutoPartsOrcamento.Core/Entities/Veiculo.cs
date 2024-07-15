
namespace AutoPartsOrcamento.Core.Entities;
public class Veiculo : Entity
{
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Ano { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string Renavam { get; set; } = string.Empty;
    public IList<ClienteVeiculo> ClienteVeiculos { get; set; } = [];

}
