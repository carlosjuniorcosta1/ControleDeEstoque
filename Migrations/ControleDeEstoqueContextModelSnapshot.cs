﻿// <auto-generated />
using System;
using ControleDeEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    [DbContext(typeof(ControleDeEstoqueContext))]
    partial class ControleDeEstoqueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ControleDeEstoque.Models.CategoriaProdutoViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoriaClasseCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdutosId")
                        .HasColumnType("int");

                    b.Property<string>("SearchString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutosId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PesquisaClientesId")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PesquisaClientesId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Fornecedor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("NomeDoFornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.PesquisaClientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int");

                    b.Property<string>("PesquisaSelecionada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SearchString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.ToTable("Pesquisas");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoriaProdutoViewModelId")
                        .HasColumnType("int");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProdutoViewModelId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.CategoriaProdutoViewModel", b =>
                {
                    b.HasOne("ControleDeEstoque.Models.Produto", "Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutosId");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Cliente", b =>
                {
                    b.HasOne("ControleDeEstoque.Models.PesquisaClientes", null)
                        .WithMany("SelectClasseClientes")
                        .HasForeignKey("PesquisaClientesId");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.PesquisaClientes", b =>
                {
                    b.HasOne("ControleDeEstoque.Models.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId");

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Produto", b =>
                {
                    b.HasOne("ControleDeEstoque.Models.CategoriaProdutoViewModel", null)
                        .WithMany("ListaDeProdutos")
                        .HasForeignKey("CategoriaProdutoViewModelId");

                    b.HasOne("ControleDeEstoque.Models.Fornecedor", null)
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.CategoriaProdutoViewModel", b =>
                {
                    b.Navigation("ListaDeProdutos");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleDeEstoque.Models.PesquisaClientes", b =>
                {
                    b.Navigation("SelectClasseClientes");
                });
#pragma warning restore 612, 618
        }
    }
}
