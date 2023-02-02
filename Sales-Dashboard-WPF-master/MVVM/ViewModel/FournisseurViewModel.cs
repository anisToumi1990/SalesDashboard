using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Sales_Dashboard.MVVM.ViewModel
{
    class FournisseurViewModel : Core.ViewModel
    {
        public ObservableCollection<Fournisseur> LoadFournisseurs()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Fournisseur> fournisseurs = context.Fournisseurs.ToList();
                ObservableCollection<Fournisseur> fournisseurCollection = new ObservableCollection<Fournisseur>(fournisseurs);
                return fournisseurCollection;
            }
        }
    }
}
