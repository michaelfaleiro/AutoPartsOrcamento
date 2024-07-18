namespace AutoPartsOrcamento.Core.Entities;

public class StatusOrcamento : Entity
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
   
}