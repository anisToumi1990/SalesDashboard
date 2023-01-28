using System;

namespace Sales_Dashboard.MVVM.Model;

public partial class OperationClient
{
    public int Id { get; set; }

    public string CodeClient { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Montant { get; set; }

    public string Libelle { get; set; }

    public string Nature { get; set; }

    public bool? CodeDeclaration { get; set; }

    public DateTime? Echeance { get; set; }

    public virtual Client CodeClientNavigation { get; set; }
}
