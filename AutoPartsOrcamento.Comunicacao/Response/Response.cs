using AutoPartsOrcamento.Comunicacao.Response.Cliente;

namespace AutoPartsOrcamento.Comunicacao.Response;
public class Response<TData> 
{
    public TData Data { get; set; } = default!;
}   

