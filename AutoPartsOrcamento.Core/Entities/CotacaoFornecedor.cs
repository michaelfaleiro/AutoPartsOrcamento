
namespace AutoPartsOrcamento.Core.Entities;

public class CotacaoFornecedor : Entity
{
   
    
    public Cotacao Cotacao { get; set; } = null!;    
    public Fornecedor Fornecedor { get;  set; } = null!;
    public string StatusCotacao { get; set; } = string.Empty;
    public IList<PrecoItemCotacao> PrecoItemCotacoes { get; set; } = [];
    public string Observacao { get; set; } = string.Empty;
}