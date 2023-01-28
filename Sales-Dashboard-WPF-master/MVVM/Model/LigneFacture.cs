using System;
using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class LigneFacture
{
    public int Id { get; set; }

    public string CodeFamille { get; set; }

    public string CodeArticle { get; set; }

    public decimal? Quantite { get; set; }

    public decimal? PrixHt { get; set; }

    public decimal? Remise { get; set; }

    public decimal? Tva { get; set; }

    public decimal? MontantHt { get; set; }

    public decimal? MontantRemise { get; set; }

    public decimal? MontantTva { get; set; }

    public decimal? NumeroFacture { get; set; }

    public string Nature { get; set; }

    public DateTime? Date { get; set; }

    public decimal? BaseFodec { get; set; }

    public decimal? MontantFodec { get; set; }

    public decimal? ValeurVente { get; set; }

    public decimal? ValeurAchat { get; set; }
}
