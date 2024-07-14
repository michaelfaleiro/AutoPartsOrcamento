using AutoPartsOrcamento.Infra.Enums;

namespace AutoPartsOrcamento.Infra.Entities;
public class Fornecedor : Entity
{
   
    public string RazaoSocial { get;  set; } = string.Empty;
    public string NomeFantasia { get;  set; } = string.Empty;
    public string Cnpj { get;  set; } = string.Empty;
    public string Ie { get;  set; } = string.Empty;
    public ETipoFornecedor Tipo { get; set; }
    public string Telefone { get;  set; } = string.Empty;
    public string Email { get;  set; } = string.Empty;       
    public IList<Contato> Contatos { get; set; } = [];
    public IList<Endereco> Enderecos { get; set; } = [];
}
