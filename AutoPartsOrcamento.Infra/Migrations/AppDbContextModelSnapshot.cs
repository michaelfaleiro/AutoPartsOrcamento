﻿// <auto-generated />
using System;
using AutoPartsOrcamento.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoPartsOrcamento.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.ClienteVeiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("ClienteVeiculos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CodigoSimilarProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CotacaoItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CotacaoItemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CodigoSimilarProdutos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Cotacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrcamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("Cotacao");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CotacaoFornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CotacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusCotacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CotacaoId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("CotacaoFornecedores");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CotacaoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CotacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CotacaoId");

                    b.ToTable("CotacaoItems");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Orcamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.OrcamentoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrcamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("OrcamentoItens");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.PrecoItemCotacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CotacaoFornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CotacaoItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrazoExpedicao")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeAtendida")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorCusto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CotacaoFornecedorId");

                    b.HasIndex("CotacaoItemId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("PrecoItemCotacoes");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorCusto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chassi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.ClienteVeiculo", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Cliente", "Cliente")
                        .WithMany("ClienteVeiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Veiculo", "Veiculo")
                        .WithMany("ClienteVeiculos")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CodigoSimilarProduto", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.CotacaoItem", null)
                        .WithMany("CodigoSimilares")
                        .HasForeignKey("CotacaoItemId");

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Produto", null)
                        .WithMany("CodigoSimilares")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Contato", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Fornecedor", null)
                        .WithMany("Contatos")
                        .HasForeignKey("FornecedorId");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Cotacao", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Orcamento", "Orcamento")
                        .WithMany("Cotacoes")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CotacaoFornecedor", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Cotacao", "Cotacao")
                        .WithMany()
                        .HasForeignKey("CotacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotacao");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CotacaoItem", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Cotacao", "Cotacao")
                        .WithMany("CotacaoItems")
                        .HasForeignKey("CotacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotacao");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Endereco", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Cliente", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Fornecedor", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("FornecedorId");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Orcamento", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.OrcamentoItem", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Orcamento", "Orcamento")
                        .WithMany("OrcamentoItems")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.PrecoItemCotacao", b =>
                {
                    b.HasOne("AutoPartsOrcamento.Infra.Entities.CotacaoFornecedor", null)
                        .WithMany("PrecoItemCotacoes")
                        .HasForeignKey("CotacaoFornecedorId");

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.CotacaoItem", "CotacaoItem")
                        .WithMany("PrecoItemCotacoes")
                        .HasForeignKey("CotacaoItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartsOrcamento.Infra.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CotacaoItem");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Cliente", b =>
                {
                    b.Navigation("ClienteVeiculos");

                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Cotacao", b =>
                {
                    b.Navigation("CotacaoItems");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CotacaoFornecedor", b =>
                {
                    b.Navigation("PrecoItemCotacoes");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.CotacaoItem", b =>
                {
                    b.Navigation("CodigoSimilares");

                    b.Navigation("PrecoItemCotacoes");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Fornecedor", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Orcamento", b =>
                {
                    b.Navigation("Cotacoes");

                    b.Navigation("OrcamentoItems");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Produto", b =>
                {
                    b.Navigation("CodigoSimilares");
                });

            modelBuilder.Entity("AutoPartsOrcamento.Infra.Entities.Veiculo", b =>
                {
                    b.Navigation("ClienteVeiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
