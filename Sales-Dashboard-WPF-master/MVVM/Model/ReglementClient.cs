using System;

namespace Sales_Dashboard.MVVM.Model;

public partial class ReglementClient
{
    public int Id { get; set; }

    public string CodeCompte { get; set; }

    public string CodeClient { get; set; }

    public string Libelle { get; set; }

    public decimal? Montant { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? Echeance { get; set; }

    public virtual Client CodeClientNavigation { get; set; }

    public virtual Compte CodeCompteNavigation { get; set; }
}
