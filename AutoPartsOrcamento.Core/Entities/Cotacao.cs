
namespace AutoPartsOrcamento.Core.Entities;
public class Cotacao : Entity
{
    public Orcamento Orcamento { get; set; } = null!;
    public IList<CotacaoItem> CotacaoItems { get; set; } = [];
    public StatusCotacao Status { get; set; } = null!;
}
