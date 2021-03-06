﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201002015409_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Deadline")
                        .HasColumnName("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnName("NumeroCotacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentTerm")
                        .HasColumnName("PrazoPagamento")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProporsalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PurchaserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TotalPrice")
                        .HasColumnName("PrecoTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProporsalId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("PurchaserId");

                    b.ToTable("Cotacao");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnName("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnName("CodProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnName("Unidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnName("Preço")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Domain.Models.ProductProvider", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnName("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProviderId")
                        .HasColumnName("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "ProviderId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProdutoFornecedor");
                });

            modelBuilder.Entity("Domain.Models.ProductQuotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnName("Quantidade")
                        .HasColumnType("float");

                    b.Property<Guid?>("PriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PriceId");

                    b.HasIndex("ProductId");

                    b.ToTable("CotacaoProduto");
                });

            modelBuilder.Entity("Domain.Models.Proporsal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnName("NumeroSolicitacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("Domain.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Domain.Models.Purchaser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comprador");
                });

            modelBuilder.Entity("Domain.Models.SupplyOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Authorization")
                        .HasColumnName("Autorizacao")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnName("NumeroOrdem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SelectedPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SelectedPriceId");

                    b.ToTable("OrdemCompra");
                });

            modelBuilder.Entity("Domain.Models.Price", b =>
                {
                    b.HasOne("Domain.Models.Proporsal", "Proporsal")
                        .WithMany("Prices")
                        .HasForeignKey("ProporsalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.HasOne("Domain.Models.Purchaser", "Purchaser")
                        .WithMany()
                        .HasForeignKey("PurchaserId");
                });

            modelBuilder.Entity("Domain.Models.ProductProvider", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("Providers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.ProductQuotation", b =>
                {
                    b.HasOne("Domain.Models.Price", "Price")
                        .WithMany("ProductQuotations")
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Domain.Models.SupplyOrder", b =>
                {
                    b.HasOne("Domain.Models.Price", "SelectedPrice")
                        .WithMany()
                        .HasForeignKey("SelectedPriceId");
                });
#pragma warning restore 612, 618
        }
    }
}
