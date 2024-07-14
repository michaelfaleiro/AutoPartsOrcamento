using AutoPartsOrcamento.Comunicacao.Response.Cliente;

namespace AutoPartsOrcamento.Comunicacao.Response;
public class Response<TData> 
{
    public List<TData> Data { get; set; } = default!;
}   

