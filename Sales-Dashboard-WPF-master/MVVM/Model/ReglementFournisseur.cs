using System;

namespace Sales_Dashboard.MVVM.Model;

public partial class ReglementFournisseur
{
    public int Id { get; set; }

    public string CodeCompte { get; set; }

    public string CodeFournisseur { get; set; }

    public DateTime? Date { get; set; }

    public string Libelle { get; set; }

    public decimal? Montant { get; set; }

    public DateTime? Echeance { get; set; }

    public virtual Compte CodeCompteNavigation { get; set; }

    public virtual Fournisseur CodeFournisseurNavigation { get; set; }
}
