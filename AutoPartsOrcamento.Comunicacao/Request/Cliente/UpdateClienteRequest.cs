﻿namespace AutoPartsOrcamento.Comunicacao.Request.Cliente;
public class UpdateClienteRequest : Request
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

}
