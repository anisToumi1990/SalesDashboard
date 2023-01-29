using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sales_Dashboard.MVVM.View
{
    /// <summary>
    /// Interaction logic for FournisseurView.xaml
    /// </summary>
    public partial class FournisseurView : UserControl
    {
        public FournisseurView()
        {
            InitializeComponent();

            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Fournisseur> fournisseurs = context.Fournisseurs.ToList();
                ObservableCollection<Fournisseur> fournisseurCollection = new ObservableCollection<Fournisseur>(fournisseurs);
                membersDataGrid.ItemsSource = fournisseurCollection;
            }
        }
    }
}
