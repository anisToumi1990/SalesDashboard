using System;

namespace Sales_Dashboard.MVVM.Model;

public partial class OperationFournisseur
{
    public int Id { get; set; }

    public string CodeFournisseur { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Montant { get; set; }

    public string Libelle { get; set; }

    public string Nature { get; set; }

    public DateTime? Echeance { get; set; }

    public virtual Fournisseur CodeFournisseurNavigation { get; set; }
}
