using Sales_Dashboard.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sales_Dashboard.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand TableauBordViewCommand { get; set; }
        public ICommand ArticlesViewCommand { get; set; }
        public ICommand VentesViewCommand { get; set; }
        public ICommand FacturesViewCommand { get; set; }
        public ICommand ClientsViewCommand { get; set; }
        public ICommand FournisseurViewCommand { get; set; }
        public ICommand ReglementsViewCommand { get; set; }
        public ICommand AdministrationViewCommand { get; set; }
        public ICommand ReglagesViewCommand { get; set; }
        public ICommand SupportViewCommand { get; set; }

        private void TableauBord(object obj) => CurrentView = new TableauBordViewModel();
        private void Articles(object obj) => CurrentView = new ArticlesViewModel();
        private void Ventes(object obj) => CurrentView = new VentesViewModel();
        private void Factures(object obj) => CurrentView = new FacturesViewModel();
        private void Clients(object obj) => CurrentView = new ClientsViewModel();
        private void Fournisseur(object obj) => CurrentView = new FournisseurViewModel();
        private void Reglements(object obj) => CurrentView = new ReglementsViewModel();
        private void Administration(object obj) => CurrentView = new AdministrationViewModel();
        private void Reglages(object obj) => CurrentView = new ReglagesViewModel();
        private void Support(object obj) => CurrentView = new SupportViewModel();

        public MainViewModel()
        {
            TableauBordViewCommand = new RelayCommand(TableauBord);
            ArticlesViewCommand = new RelayCommand(Articles);
            VentesViewCommand = new RelayCommand(Ventes);
            FacturesViewCommand = new RelayCommand(Factures);
            ClientsViewCommand = new RelayCommand(Clients);
            FournisseurViewCommand = new RelayCommand(Fournisseur);
            ReglementsViewCommand = new RelayCommand(Reglements);
            AdministrationViewCommand = new RelayCommand(Administration);
            ReglagesViewCommand = new RelayCommand(Reglages);
            SupportViewCommand = new RelayCommand(Support);
            // Startup Page
            CurrentView = new TableauBordViewModel();
        }
    }
}
