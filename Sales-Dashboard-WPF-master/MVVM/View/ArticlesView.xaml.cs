using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sales_Dashboard.MVVM.View
{
    /// <summary>
    /// Interaction logic for ArticlesView.xaml
    /// </summary>
    public partial class ArticlesView : UserControl
    {
        public ArticlesView()
        {
            InitializeComponent();

            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Article> articles = context.Articles.ToList();
                ObservableCollection<Article> artictleCollection = new ObservableCollection<Article>(articles);
                membersDataGrid.ItemsSource = artictleCollection;
            }
        }
    }
}
