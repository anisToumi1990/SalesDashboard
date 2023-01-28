using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class Article
{
    public string Code { get; set; }

    public string CodeFamille { get; set; }

    public string CodeFournisseur { get; set; }

    public string Designation { get; set; }

    public string Unite { get; set; }

    public decimal? PrixAchat { get; set; }

    public decimal? PrixVenteHt { get; set; }

    public decimal? PrixTtc { get; set; }

    public decimal? Marge { get; set; }

    public decimal? Tva { get; set; }

    public decimal? RemiseFournisseur { get; set; }

    public decimal? RemiseFacture { get; set; }

    public decimal? RemiseClient { get; set; }

    public decimal? StockDepart { get; set; }

    public decimal? QuantiteStock { get; set; }

    public decimal? QuantiteEntree { get; set; }

    public decimal? ValeurEntree { get; set; }

    public decimal? QuantiteSortie { get; set; }

    public decimal? ValeurSortie { get; set; }

    public virtual Famille CodeFamilleNavigation { get; set; }

    public virtual ICollection<LigneFacture> LigneFactures { get; } = new List<LigneFacture>();
}
