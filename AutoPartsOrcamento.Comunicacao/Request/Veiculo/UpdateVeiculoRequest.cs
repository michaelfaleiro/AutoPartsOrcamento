namespace AutoPartsOrcamento.Comunicacao.Request.Veiculo;

public class UpdateVeiculoRequest : Request
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Ano { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string Renavam { get; set; } = string.Empty;
}