﻿namespace AutoPartsOrcamento.Comunicacao.Request.Cliente;
public class CreateClienteRequest : Request
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
