namespace AutoPartsOrcamento.Comunicacao.Request.StatusCotacao;

public class UpdateStatusCotacaoRequest : Request
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}