using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Core.Entities;
public class Endereco : Entity
{
    
    public string Logradouro { get;  set; } = null!;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty; 
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public ETipoEndereco Tipo { get;set; } = ETipoEndereco.Residencial;
 }
