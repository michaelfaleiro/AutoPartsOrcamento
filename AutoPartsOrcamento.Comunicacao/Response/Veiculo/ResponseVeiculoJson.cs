﻿namespace AutoPartsOrcamento.Comunicacao.Response.Veiculo;
public class ResponseVeiculoJson
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get;  set; } = string.Empty;
    public string Ano { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string Renavam { get; set; } = string.Empty; 
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
