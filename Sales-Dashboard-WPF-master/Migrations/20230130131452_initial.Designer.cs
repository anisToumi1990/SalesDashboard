﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales_Dashboard.MVVM.Model;

#nullable disable

namespace SalesDashboard.Migrations
{
    [DbContext(typeof(StockFacturationContext))]
    [Migration("20230130131452_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CodeFamille")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CodeFournisseur")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Designation")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Marge")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<decimal?>("PrixAchat")
                        .HasColumnType("numeric(8, 3)");

                    b.Property<decimal?>("PrixTtc")
                        .HasColumnType("numeric(8, 3)")
                        .HasColumnName("PrixTTC");

                    b.Property<decimal?>("PrixVenteHt")
                        .HasColumnType("numeric(8, 3)")
                        .HasColumnName("PrixVenteHT");

                    b.Property<decimal?>("QuantiteEntree")
                        .HasColumnType("numeric(9, 2)");

                    b.Property<decimal?>("QuantiteSortie")
                        .HasColumnType("numeric(9, 2)");

                    b.Property<decimal?>("QuantiteStock")
                        .HasColumnType("numeric(9, 2)");

                    b.Property<decimal?>("RemiseClient")
                        .HasColumnType("numeric(2, 0)");

                    b.Property<decimal?>("RemiseFacture")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<decimal?>("RemiseFournisseur")
                        .HasColumnType("numeric(4, 2)");

                    b.Property<decimal?>("StockDepart")
                        .HasColumnType("numeric(9, 2)");

                    b.Property<decimal?>("Tva")
                        .HasColumnType("numeric(2, 0)")
                        .HasColumnName("TVA");

                    b.Property<string>("Unite")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<decimal?>("ValeurEntree")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("ValeurSortie")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("Article", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.BonLivraison", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("BaseTva0")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("BaseTVA0");

                    b.Property<decimal?>("BaseTva13")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("BaseTVA13");

                    b.Property<decimal?>("BaseTva19")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("BaseTVA19");

                    b.Property<decimal?>("BaseTva7")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("BaseTVA7");

                    b.Property<string>("CodeClient")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("MontantRemise")
                        .HasColumnType("numeric(9, 3)");

                    b.Property<decimal?>("MontantTtc")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("MontantTTC");

                    b.Property<string>("Nature")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<string>("NomPassager")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NumeroBonCommande")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal?>("NumeroFacture")
                        .HasColumnType("numeric(7, 0)");

                    b.Property<decimal?>("TotalAchat")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("Tva0")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("TVA0");

                    b.Property<decimal?>("Tva13")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("TVA13");

                    b.Property<decimal?>("Tva19")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("TVA19");

                    b.Property<decimal?>("Tva7")
                        .HasColumnType("numeric(11, 3)")
                        .HasColumnName("TVA7");

                    b.HasKey("Id");

                    b.ToTable("BonLivraison", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Email")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool?>("ExonoreTimbre")
                        .HasColumnType("bit");

                    b.Property<bool?>("ExonoreTva")
                        .HasColumnType("bit")
                        .HasColumnName("ExonoreTVA");

                    b.Property<string>("Fax")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("FAX");

                    b.Property<string>("Gsm")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("GSM");

                    b.Property<string>("MatriculeFiscal")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Nom")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Plafond")
                        .HasColumnType("numeric(9, 3)");

                    b.Property<decimal?>("Remise")
                        .HasColumnType("numeric(4, 2)");

                    b.Property<decimal?>("Solde")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("SoldeCredit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("SoldeDebit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<string>("Tel")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("TotalCredit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("TotalDebit")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.Compte", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<decimal?>("Credit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("Debit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<string>("Libelle")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nature")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<decimal?>("Solde")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("Compte", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.Famille", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Libelle")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Famille", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("DomiciliationBancaire")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Fax")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("Fodec")
                        .HasColumnType("numeric(3, 1)");

                    b.Property<string>("Gsm")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("GSM");

                    b.Property<string>("MatriculeFiscal")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Nom")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Rib")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("RIB");

                    b.Property<decimal?>("Solde")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("SoldeDepartCredit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("SoldeDepartDebit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<string>("Tel")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("TotalCredit")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("TotalDebit")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("Fournisseur", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.LigneFacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("BaseFodec")
                        .HasColumnType("numeric(10, 0)");

                    b.Property<string>("CodeArticle")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CodeFamille")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("MontantFodec")
                        .HasColumnType("numeric(10, 0)");

                    b.Property<decimal?>("MontantHt")
                        .HasColumnType("numeric(10, 3)")
                        .HasColumnName("MontantHT");

                    b.Property<decimal?>("MontantRemise")
                        .HasColumnType("numeric(9, 3)");

                    b.Property<decimal?>("MontantTva")
                        .HasColumnType("numeric(10, 3)")
                        .HasColumnName("MontantTVA");

                    b.Property<string>("Nature")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<decimal?>("NumeroFacture")
                        .HasColumnType("numeric(7, 0)");

                    b.Property<decimal?>("PrixHt")
                        .HasColumnType("numeric(9, 3)")
                        .HasColumnName("PrixHT");

                    b.Property<decimal?>("Quantite")
                        .HasColumnType("numeric(10, 3)");

                    b.Property<decimal?>("Remise")
                        .HasColumnType("numeric(4, 2)");

                    b.Property<decimal?>("Tva")
                        .HasColumnType("numeric(2, 0)")
                        .HasColumnName("TVA");

                    b.Property<decimal?>("ValeurAchat")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<decimal?>("ValeurVente")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("LigneFacture", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.OperationClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeClient")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<bool?>("CodeDeclaration")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Echeance")
                        .HasColumnType("date");

                    b.Property<string>("Libelle")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Montant")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<string>("Nature")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("OperationClient", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.OperationFournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeFournisseur")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Echeance")
                        .HasColumnType("date");

                    b.Property<string>("Libelle")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Montant")
                        .HasColumnType("numeric(11, 3)");

                    b.Property<string>("Nature")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("OperationFournisseur", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.ReglementClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeClient")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CodeCompte")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Echeance")
                        .HasColumnType("date");

                    b.Property<string>("Libelle")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Montant")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("ReglementClient", (string)null);
                });

            modelBuilder.Entity("Sales_Dashboard.MVVM.Model.ReglementFournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeCompte")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("CodeFournisseur")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Echeance")
                        .HasColumnType("date");

                    b.Property<string>("Libelle")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Montant")
                        .HasColumnType("numeric(11, 3)");

                    b.HasKey("Id");

                    b.ToTable("ReglementFournisseur", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
