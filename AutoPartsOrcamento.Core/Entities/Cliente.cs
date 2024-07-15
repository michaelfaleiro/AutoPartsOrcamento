
namespace AutoPartsOrcamento.Core.Entities;
public class Cliente : Entity
{
            
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
    public string CpfCnpj { get;set; } = string.Empty;
    public string Telefone { get;set; } = string.Empty;
    public IList<Endereco> Enderecos { get; set; } = [];
    public IList<ClienteVeiculo> ClienteVeiculos { get;set; } = [];
    
}
