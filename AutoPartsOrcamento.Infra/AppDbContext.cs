using AutoPartsOrcamento.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsOrcamento.Infra;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<ClienteVeiculo> ClienteVeiculos { get; set; } = null!;
    public DbSet<CodigoSimilarProduto> CodigoSimilarProdutos { get; set; } = null!;
    public DbSet<Contato> Contatos { get; set; } = null!;
    public DbSet<Cotacao> Cotacao { get; set; } = null!;
    public DbSet<CotacaoFornecedor> CotacaoFornecedores { get; set; } = null!;
    public DbSet<CotacaoItem> CotacaoItems { get; set; } = null!;
    public DbSet<Endereco> Enderecos { get; set; } = null!;
    public DbSet<Fornecedor> Fornecedores { get; set; } = null!;
    public DbSet<Orcamento> Orcamentos { get; set; } = null!;
    public DbSet<OrcamentoItem> OrcamentoItens { get; set; } = null!;
    public DbSet<PrecoItemCotacao> PrecoItemCotacoes { get; set; } = null!;
    public DbSet<Produto> Produtos { get; set; } = null!;
    public DbSet<Veiculo> Veiculos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}
