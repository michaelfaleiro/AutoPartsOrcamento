using AutoPartsOrcamento.Comunicacao.Response.Cliente;
using AutoPartsOrcamento.Comunicacao.Response.Item;
using AutoPartsOrcamento.Comunicacao.Response.Veiculo;

namespace AutoPartsOrcamento.Comunicacao.Response.Cotacao;

public class ResponseCotacaoJson
{
    public Guid Id { get; set; }
    public ResponseClienteJson Cliente { get; set; } = new();
    public ResponseVeiculoJson Veiculo { get; set; } = new();
    public List<ResponseItemCotacaoJson> Items { get; set; } = [];
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}