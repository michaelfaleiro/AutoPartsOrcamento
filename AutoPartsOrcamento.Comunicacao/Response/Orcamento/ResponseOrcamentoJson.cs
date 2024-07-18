using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Cotacao;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;

namespace AutoPartsOrcamento.Comunicacao.Response.Orcamento;

public class ResponseOrcamentoJson
{
    public Guid Id { get; set; }
    public ResponseClienteJson Cliente { get; set; } = null!;
    public ResponseVeiculoJson Veiculo { get; set; } = null!;
    public IList<ResponseOrcamentoItemJson> Items { get; set; } = [];
    public IList<ResponseCotacaoJson> Cotacoes { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}