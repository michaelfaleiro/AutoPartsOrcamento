using AutoPartsOrcamento.Core.Enums;

namespace AutoPartsOrcamento.Comunicacao.Request.Fornecedor
{
    public class UpdateFornecedorRequest : Request
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Ie { get; set; } = string.Empty;
        public ETipoFornecedor Tipo { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}