﻿using System;
using System.Collections.Generic;

namespace Sales_Dashboard.MVVM.Model;

public partial class Client
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Nom { get; set; }

    public string Adresse { get; set; }

    public string Tel { get; set; }

    public string Gsm { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string MatriculeFiscal { get; set; }

    public bool? ExonoreTva { get; set; }

    public bool? ExonoreTimbre { get; set; }

    public decimal? Remise { get; set; }

    public decimal? Plafond { get; set; }

    public decimal? SoldeDebit { get; set; }

    public decimal? SoldeCredit { get; set; }

    public decimal? TotalDebit { get; set; }

    public decimal? TotalCredit { get; set; }

    public decimal? Solde { get; set; }
}
