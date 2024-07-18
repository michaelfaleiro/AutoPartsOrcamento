namespace AutoPartsOrcamento.Comunicacao.Response.StatusOrcamento;

public class ResponseStatusOrcamentoJson
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}