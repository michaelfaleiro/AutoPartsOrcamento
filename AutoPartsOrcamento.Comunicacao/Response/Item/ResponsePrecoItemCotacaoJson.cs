using AutoPartsOrcamento.Comunicacao.Response.Fornecedor;

namespace AutoPartsOrcamento.Comunicacao.Response.Item;

public class ResponsePrecoItemCotacaoJson
{
    public Guid Id { get; set; }
    public int QuantidadeAtendida { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public int PrazoExpedicao { get; set; }
    public string Observacao { get; set; } = string.Empty;
    public ResponseFornecedorJson Fornecedor { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}