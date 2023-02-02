using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesDashboard.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CodeFamille = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CodeFournisseur = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Unite = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PrixAchat = table.Column<decimal>(type: "numeric(8,3)", nullable: true),
                    PrixVenteHT = table.Column<decimal>(type: "numeric(8,3)", nullable: true),
                    PrixTTC = table.Column<decimal>(type: "numeric(8,3)", nullable: true),
                    Marge = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TVA = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    RemiseFournisseur = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    RemiseFacture = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    RemiseClient = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    StockDepart = table.Column<decimal>(type: "numeric(9,2)", nullable: true),
                    QuantiteStock = table.Column<decimal>(type: "numeric(9,2)", nullable: true),
                    QuantiteEntree = table.Column<decimal>(type: "numeric(9,2)", nullable: true),
                    ValeurEntree = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    QuantiteSortie = table.Column<decimal>(type: "numeric(9,2)", nullable: true),
                    ValeurSortie = table.Column<decimal>(type: "numeric(11,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonLivraison",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFacture = table.Column<decimal>(type: "numeric(7,0)", nullable: true),
                    NumeroBonCommande = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    CodeClient = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BaseTVA0 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    BaseTVA7 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    BaseTVA13 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    BaseTVA19 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TVA0 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TVA7 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TVA13 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TVA19 = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    MontantRemise = table.Column<decimal>(type: "numeric(9,3)", nullable: true),
                    MontantTTC = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Nature = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    TotalAchat = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    NomPassager = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonLivraison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GSM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FAX = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MatriculeFiscal = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    ExonoreTVA = table.Column<bool>(type: "bit", nullable: true),
                    ExonoreTimbre = table.Column<bool>(type: "bit", nullable: true),
                    Remise = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Plafond = table.Column<decimal>(type: "numeric(9,3)", nullable: true),
                    SoldeDebit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    SoldeCredit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TotalDebit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TotalCredit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Solde = table.Column<decimal>(type: "numeric(11,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nature = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Debit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Credit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Solde = table.Column<decimal>(type: "numeric(11,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Famille",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Famille", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GSM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MatriculeFiscal = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    DomiciliationBancaire = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RIB = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fodec = table.Column<decimal>(type: "numeric(3,1)", nullable: true),
                    SoldeDepartDebit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    SoldeDepartCredit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TotalDebit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    TotalCredit = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Solde = table.Column<decimal>(type: "numeric(11,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LigneFacture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeFamille = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CodeArticle = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Quantite = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    PrixHT = table.Column<decimal>(type: "numeric(9,3)", nullable: true),
                    Remise = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    TVA = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    MontantHT = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    MontantRemise = table.Column<decimal>(type: "numeric(9,3)", nullable: true),
                    MontantTVA = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    NumeroFacture = table.Column<decimal>(type: "numeric(7,0)", nullable: true),
                    Nature = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    BaseFodec = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    MontantFodec = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    ValeurVente = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    ValeurAchat = table.Column<decimal>(type: "numeric(11,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFacture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeClient = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Montant = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Nature = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    CodeDeclaration = table.Column<bool>(type: "bit", nullable: true),
                    Echeance = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationFournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeFournisseur = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Montant = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Nature = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Echeance = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationFournisseur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReglementClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeCompte = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CodeClient = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Montant = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Echeance = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglementClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReglementFournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeCompte = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CodeFournisseur = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Montant = table.Column<decimal>(type: "numeric(11,3)", nullable: true),
                    Echeance = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglementFournisseur", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "BonLivraison");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Compte");

            migrationBuilder.DropTable(
                name: "Famille");

            migrationBuilder.DropTable(
                name: "Fournisseur");

            migrationBuilder.DropTable(
                name: "LigneFacture");

            migrationBuilder.DropTable(
                name: "OperationClient");

            migrationBuilder.DropTable(
                name: "OperationFournisseur");

            migrationBuilder.DropTable(
                name: "ReglementClient");

            migrationBuilder.DropTable(
                name: "ReglementFournisseur");
        }
    }
}
