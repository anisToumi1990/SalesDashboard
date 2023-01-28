using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sales_Dashboard.MVVM.Model;

public partial class StockFacturationContext : DbContext
{
    public StockFacturationContext()
    {
    }

    public StockFacturationContext(DbContextOptions<StockFacturationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<BonLivraison> BonLivraisons { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Compte> Comptes { get; set; }

    public virtual DbSet<Famille> Familles { get; set; }

    public virtual DbSet<Fournisseur> Fournisseurs { get; set; }

    public virtual DbSet<LigneFacture> LigneFactures { get; set; }

    public virtual DbSet<OperationClient> OperationClients { get; set; }

    public virtual DbSet<OperationFournisseur> OperationFournisseurs { get; set; }

    public virtual DbSet<ReglementClient> ReglementClients { get; set; }

    public virtual DbSet<ReglementFournisseur> ReglementFournisseurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-MQP5001E\\SQLEXPRESS;Initial Catalog=StockFacturation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Code).HasMaxLength(11);
            entity.Property(e => e.CodeFamille).HasMaxLength(5);
            entity.Property(e => e.CodeFournisseur).HasMaxLength(5);
            entity.Property(e => e.Designation).HasMaxLength(40);
            entity.Property(e => e.Marge).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PrixAchat).HasColumnType("numeric(8, 3)");
            entity.Property(e => e.PrixTtc)
                .HasColumnType("numeric(8, 3)")
                .HasColumnName("PrixTTC");
            entity.Property(e => e.PrixVenteHt)
                .HasColumnType("numeric(8, 3)")
                .HasColumnName("PrixVenteHT");
            entity.Property(e => e.QuantiteEntree).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.QuantiteSortie).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.QuantiteStock).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.RemiseClient).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.RemiseFacture).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.RemiseFournisseur).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.StockDepart).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.Tva)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("TVA");
            entity.Property(e => e.Unite).HasMaxLength(2);
            entity.Property(e => e.ValeurEntree).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.ValeurSortie).HasColumnType("numeric(11, 3)");
        });

        modelBuilder.Entity<BonLivraison>(entity =>
        {
            entity.ToTable("BonLivraison");

            entity.Property(e => e.BaseTva0)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("BaseTVA0");
            entity.Property(e => e.BaseTva13)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("BaseTVA13");
            entity.Property(e => e.BaseTva19)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("BaseTVA19");
            entity.Property(e => e.BaseTva7)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("BaseTVA7");
            entity.Property(e => e.CodeClient).HasMaxLength(5);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MontantRemise).HasColumnType("numeric(9, 3)");
            entity.Property(e => e.MontantTtc)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("MontantTTC");
            entity.Property(e => e.Nature)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NomPassager).HasMaxLength(40);
            entity.Property(e => e.NumeroBonCommande).HasMaxLength(15);
            entity.Property(e => e.NumeroFacture).HasColumnType("numeric(7, 0)");
            entity.Property(e => e.TotalAchat).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Tva0)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("TVA0");
            entity.Property(e => e.Tva13)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("TVA13");
            entity.Property(e => e.Tva19)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("TVA19");
            entity.Property(e => e.Tva7)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("TVA7");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Adresse).HasMaxLength(40);
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.ExonoreTva).HasColumnName("ExonoreTVA");
            entity.Property(e => e.Fax)
                .HasMaxLength(10)
                .HasColumnName("FAX");
            entity.Property(e => e.Gsm)
                .HasMaxLength(10)
                .HasColumnName("GSM");
            entity.Property(e => e.MatriculeFiscal).HasMaxLength(18);
            entity.Property(e => e.Nom).HasMaxLength(40);
            entity.Property(e => e.Plafond).HasColumnType("numeric(9, 3)");
            entity.Property(e => e.Remise).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.Solde).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.SoldeCredit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.SoldeDebit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Tel).HasMaxLength(10);
            entity.Property(e => e.TotalCredit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.TotalDebit).HasColumnType("numeric(11, 3)");
        });

        modelBuilder.Entity<Compte>(entity =>
        {
            entity.ToTable("Compte");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(2);
            entity.Property(e => e.Credit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Debit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Libelle).HasMaxLength(30);
            entity.Property(e => e.Nature)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Solde).HasColumnType("numeric(11, 3)");
        });

        modelBuilder.Entity<Famille>(entity =>
        {
            entity.ToTable("Famille");

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Libelle).HasMaxLength(25);
        });

        modelBuilder.Entity<Fournisseur>(entity =>
        {
            entity.ToTable("Fournisseur");

            entity.Property(e => e.Adresse).HasMaxLength(40);
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DomiciliationBancaire).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Fax).HasMaxLength(10);
            entity.Property(e => e.Fodec).HasColumnType("numeric(3, 1)");
            entity.Property(e => e.Gsm)
                .HasMaxLength(10)
                .HasColumnName("GSM");
            entity.Property(e => e.MatriculeFiscal).HasMaxLength(18);
            entity.Property(e => e.Nom).HasMaxLength(40);
            entity.Property(e => e.Rib)
                .HasMaxLength(20)
                .HasColumnName("RIB");
            entity.Property(e => e.Solde).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.SoldeDepartCredit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.SoldeDepartDebit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Tel).HasMaxLength(10);
            entity.Property(e => e.TotalCredit).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.TotalDebit).HasColumnType("numeric(11, 3)");
        });

        modelBuilder.Entity<LigneFacture>(entity =>
        {
            entity.ToTable("LigneFacture");

            entity.Property(e => e.BaseFodec).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.CodeArticle).HasMaxLength(11);
            entity.Property(e => e.CodeFamille).HasMaxLength(5);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MontantFodec).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.MontantHt)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("MontantHT");
            entity.Property(e => e.MontantRemise).HasColumnType("numeric(9, 3)");
            entity.Property(e => e.MontantTva)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("MontantTVA");
            entity.Property(e => e.Nature)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NumeroFacture).HasColumnType("numeric(7, 0)");
            entity.Property(e => e.PrixHt)
                .HasColumnType("numeric(9, 3)")
                .HasColumnName("PrixHT");
            entity.Property(e => e.Quantite).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.Remise).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.Tva)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("TVA");
            entity.Property(e => e.ValeurAchat).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.ValeurVente).HasColumnType("numeric(11, 3)");
        });

        modelBuilder.Entity<OperationClient>(entity =>
        {
            entity.ToTable("OperationClient");

            entity.Property(e => e.CodeClient).HasMaxLength(5);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Echeance).HasColumnType("date");
            entity.Property(e => e.Libelle).HasMaxLength(40);
            entity.Property(e => e.Montant).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Nature)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OperationFournisseur>(entity =>
        {
            entity.ToTable("OperationFournisseur");

            entity.Property(e => e.CodeFournisseur).HasMaxLength(5);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Echeance).HasColumnType("date");
            entity.Property(e => e.Libelle).HasMaxLength(40);
            entity.Property(e => e.Montant).HasColumnType("numeric(11, 3)");
            entity.Property(e => e.Nature)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<ReglementClient>(entity =>
        {
            entity.ToTable("ReglementClient");

            entity.Property(e => e.CodeClient).HasMaxLength(5);
            entity.Property(e => e.CodeCompte).HasMaxLength(2);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Echeance).HasColumnType("date");
            entity.Property(e => e.Libelle).HasMaxLength(40);
            entity.Property(e => e.Montant).HasColumnType("numeric(11, 3)");
        });

        modelBuilder.Entity<ReglementFournisseur>(entity =>
        {
            entity.ToTable("ReglementFournisseur");

            entity.Property(e => e.CodeCompte).HasMaxLength(2);
            entity.Property(e => e.CodeFournisseur).HasMaxLength(5);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Echeance).HasColumnType("date");
            entity.Property(e => e.Libelle).HasMaxLength(40);
            entity.Property(e => e.Montant).HasColumnType("numeric(11, 3)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
