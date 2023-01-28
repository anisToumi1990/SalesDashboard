using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class Fournisseur
{
    public string Code { get; set; }

    public string Nom { get; set; }

    public string Adresse { get; set; }

    public string Tel { get; set; }

    public string Gsm { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string MatriculeFiscal { get; set; }

    public string DomiciliationBancaire { get; set; }

    public string Rib { get; set; }

    public decimal? Fodec { get; set; }

    public decimal? SoldeDepartDebit { get; set; }

    public decimal? SoldeDepartCredit { get; set; }

    public decimal? TotalDebit { get; set; }

    public decimal? TotalCredit { get; set; }

    public decimal? Solde { get; set; }

    public virtual ICollection<OperationFournisseur> OperationFournisseurs { get; } = new List<OperationFournisseur>();

    public virtual ICollection<ReglementFournisseur> ReglementFournisseurs { get; } = new List<ReglementFournisseur>();
}
