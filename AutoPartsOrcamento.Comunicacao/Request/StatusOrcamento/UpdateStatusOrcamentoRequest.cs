namespace AutoPartsOrcamento.Comunicacao.Request.StatusOrcamento;

public class UpdateStatusOrcamentoRequest : Request
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}