﻿using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class Compte
{
    public string Code { get; set; }

    public string Libelle { get; set; }

    public string Nature { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }

    public decimal? Solde { get; set; }

    public virtual ICollection<ReglementClient> ReglementClients { get; } = new List<ReglementClient>();

    public virtual ICollection<ReglementFournisseur> ReglementFournisseurs { get; } = new List<ReglementFournisseur>();
}
