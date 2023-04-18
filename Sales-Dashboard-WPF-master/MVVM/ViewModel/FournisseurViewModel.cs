using Sales_Dashboard.Core;
using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Sales_Dashboard.MVVM.ViewModel
{
    class FournisseurViewModel : Core.ViewModel
    {
        #region Props and declarations
        private ObservableCollection<Fournisseur> _lstFournisseurs;
        public ObservableCollection<Fournisseur> LstFournisseurs
        {
            get { return _lstFournisseurs; }
            set
            {
                _lstFournisseurs = value;
                OnPropertyChanged(nameof(LstFournisseurs));
            }
        }

        private Fournisseur _selectedFournisseur;
        public Fournisseur SelectedFournisseur
        {
            get { return _selectedFournisseur; }
            set
            {
                _selectedFournisseur = value;
                OnPropertyChanged(nameof(SelectedFournisseur));
            }
        }

        private bool _isFournisseurEditPopup;
        public bool IsFournisseurEditPopup
        {
            get { return _isFournisseurEditPopup; }
            set
            {
                _isFournisseurEditPopup = value;
                OnPropertyChanged(nameof(IsFournisseurEditPopup));
            }
        }

        private bool _isFournisseurAddPopup;
        public bool IsFournisseurAddPopup
        {
            get { return _isFournisseurAddPopup; }
            set
            {
                _isFournisseurAddPopup = value;
                OnPropertyChanged(nameof(IsFournisseurAddPopup));
            }
        }

        private bool _isFournisseurEnabled;
        public bool IsFournisseurEnabled
        {
            get { return _isFournisseurEnabled; }
            set
            {
                _isFournisseurEnabled = value;
                OnPropertyChanged(nameof(IsFournisseurEnabled));
            }
        }

        private double _fournisseurOpacity;
        public double FournisseurOpacity
        {
            get { return _fournisseurOpacity; }
            set
            {
                _fournisseurOpacity = value;
                OnPropertyChanged(nameof(FournisseurOpacity));
            }
        }

        private Fournisseur _newFournisseur;
        public Fournisseur NewFournisseur
        {
            get { return _newFournisseur; }
            set
            {
                _newFournisseur = value;
                OnPropertyChanged(nameof(NewFournisseur));
            }
        }

        public ICommand DeleteFournisseurCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateFournisseurCommand { get; set; }
        public ICommand CloseUpdateFournisseurCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddFournisseurCommand { get; set; }
        public ICommand CloseAddFournisseurCommand { get; set; }

        #endregion

        public FournisseurViewModel()
        {
            InitFocus();
            LoadFournisseurs();
            InstanciateCommands();
        }

        #region Loads
        public void LoadFournisseurs()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Fournisseur> fournisseurs = context.Fournisseurs.ToList();
                LstFournisseurs = new ObservableCollection<Fournisseur>(fournisseurs);
            }
        }
        #endregion

        #region Crud Functions
        private void Delete(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var fournisseurToDelete = obj as Fournisseur;
                context.Fournisseurs.Remove(fournisseurToDelete);
                context.SaveChanges();
                LstFournisseurs.Remove(fournisseurToDelete);
            }
        }
        private void Update(object obj)
        {
            SelectedFournisseur = obj as Fournisseur;
            SwitchFocusUpdate();
        }
        private void UpdateFournisseur(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var fam = context.Fournisseurs.FirstOrDefault(e => e.Id == SelectedFournisseur.Id);
                if (fam != null)
                {
                    fam.Nom = SelectedFournisseur.Nom;
                    fam.Adresse = SelectedFournisseur.Adresse;
                    fam.Tel = SelectedFournisseur.Tel;
                    fam.Email = SelectedFournisseur.Email;
                    fam.MatriculeFiscal = SelectedFournisseur.MatriculeFiscal;
                    fam.DomiciliationBancaire = SelectedFournisseur.DomiciliationBancaire;
                    fam.Rib = SelectedFournisseur.Rib;
                }
                context.SaveChanges();
            }
            SwitchFocusUpdate();
        }
        private void CloseUpdateFournisseur(object obj)
        {
            LoadFournisseurs();
            SwitchFocusUpdate();
        }
        private void Add(object obj)
        {
            NewFournisseur = new Fournisseur();
            SwitchFocusAdd();
        }
        private void AddFournisseur(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                context.Fournisseurs.Add(NewFournisseur);
                context.SaveChanges();
            }
            LstFournisseurs.Add(NewFournisseur);
            NewFournisseur = new Fournisseur();
            SwitchFocusAdd();
        }
        private void CloseAddFournisseur(object obj)
        {
            NewFournisseur = new Fournisseur();
            SwitchFocusAdd();
        }
        #endregion

        #region Utilities
        private void InstanciateCommands()
        {
            DeleteFournisseurCommand = new RelayCommand(Delete, (s) => true);
            UpdateCommand = new RelayCommand(Update, (s) => true);
            UpdateFournisseurCommand = new RelayCommand(UpdateFournisseur, (s) => true);
            CloseUpdateFournisseurCommand = new RelayCommand(CloseUpdateFournisseur, (s) => true);
            AddCommand = new RelayCommand(Add, (s) => true);
            AddFournisseurCommand = new RelayCommand(AddFournisseur, (s) => true);
            CloseAddFournisseurCommand = new RelayCommand(CloseAddFournisseur, (s) => true);
        }
        private void InitFocus()
        {
            IsFournisseurAddPopup = false;
            IsFournisseurEditPopup = false;
            IsFournisseurEnabled = true;
            FournisseurOpacity = 1.0;
        }
        private void SwitchFocusAdd()
        {
            SwitchFocus();
            IsFournisseurAddPopup = !IsFournisseurAddPopup;
        }
        private void SwitchFocusUpdate()
        {
            SwitchFocus();
            IsFournisseurEditPopup = !IsFournisseurEditPopup;
        }
        private void SwitchFocus()
        {
            IsFournisseurEnabled = !IsFournisseurEnabled;
            FournisseurOpacity = IsFournisseurEnabled ? 1.0 : 0.5;
        }
        #endregion
    }
}
