using System;
using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class BonLivraison
{
    public int Id { get; set; }

    public decimal? NumeroFacture { get; set; }

    public string NumeroBonCommande { get; set; }

    public DateTime? Date { get; set; }

    public string CodeClient { get; set; }

    public decimal? BaseTva0 { get; set; }

    public decimal? BaseTva7 { get; set; }

    public decimal? BaseTva13 { get; set; }

    public decimal? BaseTva19 { get; set; }

    public decimal? Tva0 { get; set; }

    public decimal? Tva7 { get; set; }

    public decimal? Tva13 { get; set; }

    public decimal? Tva19 { get; set; }

    public decimal? MontantRemise { get; set; }

    public decimal? MontantTtc { get; set; }

    public string Nature { get; set; }

    public decimal? TotalAchat { get; set; }

    public string NomPassager { get; set; }
}
