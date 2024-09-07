﻿// <auto-generated />
using System;
using AutoTrackApi.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoTrack.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20240829203149_camposunique")]
    partial class camposunique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("AutoTrackApi.Model.Entities.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataUltAlt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Produto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("estoques");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Entities.Orcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EstoqueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MontagemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeServico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Produto")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ServicoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorParcial")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("MontagemId");

                    b.HasIndex("ServicoId");

                    b.ToTable("orcamentos");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Montagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoFab")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoReteste")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocumentacaoAno")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GeracaoInstaladores")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("KitDaLoja")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Litro")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarcaCilindro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MarcaValvula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroCilindro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroLaudoMontagem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroNFEquipamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroNFServicoMontagem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroOrdemRequalificacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroValvula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Orcamento")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantPecaServico")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Quilo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RedutorValor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Requalificadora")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Selo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("TEXT");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("data")
                        .HasColumnType("TEXT");

                    b.Property<bool>("pago")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("montagens");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataServico")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaPag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mecanico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Totalorcamento")
                        .HasColumnType("TEXT");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("dataalerta")
                        .HasColumnType("TEXT");

                    b.Property<bool>("pago")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("servicos");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnoFab")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AnoModelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Capacidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Carro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Chassi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Combustivel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Garantia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KmAtual")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Potencia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProxManutencao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProxTrocaFiltro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Chassi")
                        .IsUnique();

                    b.HasIndex("ClienteId");

                    b.HasIndex("Placa")
                        .IsUnique();

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InsEstadual")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InsMunicipal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InsTelefone2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Entities.Orcamento", b =>
                {
                    b.HasOne("AutoTrackApi.Model.Entities.Estoque", "estoque")
                        .WithMany()
                        .HasForeignKey("EstoqueId");

                    b.HasOne("AutoTrackApi.Model.Montagem", "Montagem")
                        .WithMany("orcamentos")
                        .HasForeignKey("MontagemId");

                    b.HasOne("AutoTrackApi.Model.Servico", "Servico")
                        .WithMany("orcamentos")
                        .HasForeignKey("ServicoId");

                    b.Navigation("Montagem");

                    b.Navigation("Servico");

                    b.Navigation("estoque");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Montagem", b =>
                {
                    b.HasOne("AutoTrackApi.Model.Veiculo", "veiculo")
                        .WithMany("montagens")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("veiculo");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Servico", b =>
                {
                    b.HasOne("AutoTrackApi.Model.Veiculo", "veiculo")
                        .WithMany("servicos")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("veiculo");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Veiculo", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany("Veiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Montagem", b =>
                {
                    b.Navigation("orcamentos");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Servico", b =>
                {
                    b.Navigation("orcamentos");
                });

            modelBuilder.Entity("AutoTrackApi.Model.Veiculo", b =>
                {
                    b.Navigation("montagens");

                    b.Navigation("servicos");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
