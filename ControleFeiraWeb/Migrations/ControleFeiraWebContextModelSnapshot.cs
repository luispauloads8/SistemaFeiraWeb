﻿// <auto-generated />
using System;
using ControleFeiraWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleFeiraWeb.Migrations
{
    [DbContext(typeof(ControleFeiraWebContext))]
    partial class ControleFeiraWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleFeiraWeb.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("ControleFeiraWeb.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<DateTime>("Data_Nascimento");

                    b.Property<int?>("DepartamentoId");

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.Property<string>("Profissao");

                    b.Property<string>("RG");

                    b.Property<string>("Telefone_Celular");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ControleFeiraWeb.Models.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataLancamento");

                    b.Property<string>("Descricao");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int?>("ProdutoId");

                    b.Property<int>("Status");

                    b.Property<double>("ValorLancamento");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Lancamento");
                });

            modelBuilder.Entity("ControleFeiraWeb.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descrição");

                    b.Property<int?>("ProdutoId");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ControleFeiraWeb.Models.Funcionario", b =>
                {
                    b.HasOne("ControleFeiraWeb.Models.Departamento", "Departamento")
                        .WithMany("Funcionarios")
                        .HasForeignKey("DepartamentoId");
                });

            modelBuilder.Entity("ControleFeiraWeb.Models.Lancamento", b =>
                {
                    b.HasOne("ControleFeiraWeb.Models.Funcionario", "Funcionario")
                        .WithMany("Lancamentos")
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("ControleFeiraWeb.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("ControleFeiraWeb.Models.Produto", b =>
                {
                    b.HasOne("ControleFeiraWeb.Models.Produto")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId");
                });
#pragma warning restore 612, 618
        }
    }
}
