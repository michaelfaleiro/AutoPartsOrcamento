namespace AutoPartsOrcamento.Comunicacao.Request.Orcamento;

public class AdicionarItemOrcamentoRequest : Request
{
    public Guid OrcamentoId { get; set; }
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}