using AutoPartsOrcamento.Comunicacao.Response.Veiculo;

namespace AutoPartsOrcamento.Comunicacao.Response.Cliente;
public class ResponseClienteComVeiculosJson : ResponseClienteJson
{
    public IList<ResponseVeiculoJson> Veiculos { get; set; } = [];
}
