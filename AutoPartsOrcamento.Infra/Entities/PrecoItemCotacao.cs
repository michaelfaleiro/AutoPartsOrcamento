namespace AutoPartsOrcamento.Infra.Entities;
public class PrecoItemCotacao : Entity
{
        
    public CotacaoItem CotacaoItem { get; set; } = null!;
    public int QuantidadeAtendida { get;  set; }
    public string Sku { get; set; } = null!;
    public decimal ValorCusto { get;  set; }
    public decimal ValorVenda { get;  set; }
    public int PrazoExpedicao { get;  set; }
    public string Observacao { get;  set; } = string.Empty;
    public Fornecedor Fornecedor { get;  set; } = null!;
}
