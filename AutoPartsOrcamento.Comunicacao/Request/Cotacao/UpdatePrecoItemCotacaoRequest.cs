namespace AutoPartsOrcamento.Comunicacao.Request.Cotacao;

public class UpdatePrecoItemCotacaoRequest : Request
{
    public Guid PrecoItemId { get; set; }
    public Guid ItemId { get; set; }
    public Guid FornecedorId { get; set; }
    public int QuantidadeAtendida { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public int PrazoExpedicao { get; set; }
    public string Observacao { get; set; } = string.Empty;
}