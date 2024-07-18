namespace AutoPartsOrcamento.Core.Entities;

public class StatusCotacao : Entity
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}