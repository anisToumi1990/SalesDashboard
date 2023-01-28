using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class Famille
{
    public string Code { get; set; }

    public string Libelle { get; set; }

    public virtual ICollection<Article> Articles { get; } = new List<Article>();

    public virtual ICollection<LigneFacture> LigneFactures { get; } = new List<LigneFacture>();
}
