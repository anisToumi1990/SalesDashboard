using Sales_Dashboard.Core;
using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sales_Dashboard.MVVM.ViewModel
{
    class FamilleArticlesViewModel : Core.ViewModel
    {
        #region Props and declarations
        private ObservableCollection<Famille> _lstFamilleArticles;
        public ObservableCollection<Famille> LstFamilleArticles
        {
            get { return _lstFamilleArticles; }
            set
            {
                _lstFamilleArticles = value;
                OnPropertyChanged(nameof(LstFamilleArticles));
            }
        }

        private Famille _selectedFamilleArticle;
        public Famille SelectedFamilleArticle
        {
            get { return _selectedFamilleArticle; }
            set
            {
                _selectedFamilleArticle = value;
                OnPropertyChanged(nameof(SelectedFamilleArticle));
            }
        }

        private bool _isFamilleArticleEditPopup;
        public bool IsFamilleArticleEditPopup
        {
            get { return _isFamilleArticleEditPopup; }
            set
            {
                _isFamilleArticleEditPopup = value;
                OnPropertyChanged(nameof(IsFamilleArticleEditPopup));
            }
        }

        private bool _isFamilleArticleAddPopup;
        public bool IsFamilleArticleAddPopup
        {
            get { return _isFamilleArticleAddPopup; }
            set
            {
                _isFamilleArticleAddPopup = value;
                OnPropertyChanged(nameof(IsFamilleArticleAddPopup));
            }
        }

        private bool _isFamilleArticlesEnabled;
        public bool IsFamilleArticlesEnabled
        {
            get { return _isFamilleArticlesEnabled; }
            set
            {
                _isFamilleArticlesEnabled = value;
                OnPropertyChanged(nameof(IsFamilleArticlesEnabled));
            }
        }

        private double _familleArticlesOpacity;
        public double FamilleArticlesOpacity
        {
            get { return _familleArticlesOpacity; }
            set
            {
                _familleArticlesOpacity = value;
                OnPropertyChanged(nameof(FamilleArticlesOpacity));
            }
        }

        private Famille _newFamilleArticle;
        public Famille NewFamilleArticle
        {
            get { return _newFamilleArticle; }
            set
            {
                _newFamilleArticle = value;
                OnPropertyChanged(nameof(NewFamilleArticle));
            }
        }

        public ICommand DeleteFamilleArticleCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateFamilleArticleCommand { get; set; }
        public ICommand CloseUpdateFamilleArticleCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddFamilleArticleCommand { get; set; }
        public ICommand CloseAddFamilleArticleCommand { get; set; }

        #endregion

        public FamilleArticlesViewModel()
        {
            InitFocus();
            LoadFamilleArticles();
            InstanciateCommands();
        }

        #region Loads
        public void LoadFamilleArticles()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Famille> familleArticles = context.Familles.ToList();
                LstFamilleArticles = new ObservableCollection<Famille>(familleArticles);
            }
        }
        #endregion

        #region Crud Functions
        private void Delete(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var familleArticleToDelete = obj as Famille;
                context.Familles.Remove(familleArticleToDelete);
                context.SaveChanges();
                LstFamilleArticles.Remove(familleArticleToDelete);
            }
        }
        private void Update(object obj)
        {
            SelectedFamilleArticle = obj as Famille;
            SwitchFocusUpdate();
        }
        private void UpdateFamilleArticle(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var fam = context.Familles.FirstOrDefault(e => e.Id == SelectedFamilleArticle.Id);
                if (fam != null)
                {
                    fam.Code = SelectedFamilleArticle.Code;
                    fam.Libelle = SelectedFamilleArticle.Libelle;
                }
                context.SaveChanges();
            }
            SwitchFocusUpdate();
        }
        private void CloseUpdateFamilleArticle(object obj)
        {
            LoadFamilleArticles();
            SwitchFocusUpdate();
        }
        private void Add(object obj)
        {
            NewFamilleArticle = new Famille();
            SwitchFocusAdd();
        }
        private void AddFamilleArticle(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                context.Familles.Add(NewFamilleArticle);
                context.SaveChanges();
            }
            LstFamilleArticles.Add(NewFamilleArticle);
            NewFamilleArticle = new Famille();
            SwitchFocusAdd();
        }
        private void CloseAddFamilleArticle(object obj)
        {
            NewFamilleArticle = new Famille();
            SwitchFocusAdd();
        }
        #endregion

        #region Utilities
        private void InstanciateCommands()
        {
            DeleteFamilleArticleCommand = new RelayCommand(Delete, (s) => true);
            UpdateCommand = new RelayCommand(Update, (s) => true);
            UpdateFamilleArticleCommand = new RelayCommand(UpdateFamilleArticle, (s) => true);
            CloseUpdateFamilleArticleCommand = new RelayCommand(CloseUpdateFamilleArticle, (s) => true);
            AddCommand = new RelayCommand(Add, (s) => true);
            AddFamilleArticleCommand = new RelayCommand(AddFamilleArticle, (s) => true);
            CloseAddFamilleArticleCommand = new RelayCommand(CloseAddFamilleArticle, (s) => true);
        }
        private void InitFocus()
        {
            IsFamilleArticleAddPopup = false;
            IsFamilleArticleEditPopup = false;
            IsFamilleArticlesEnabled = true;
            FamilleArticlesOpacity = 1.0;
        }
        private void SwitchFocusAdd()
        {
            SwitchFocus();
            IsFamilleArticleAddPopup = !IsFamilleArticleAddPopup;
        }
        private void SwitchFocusUpdate()
        {
            SwitchFocus();
            IsFamilleArticleEditPopup = !IsFamilleArticleEditPopup;
        }
        private void SwitchFocus()
        {
            IsFamilleArticlesEnabled = !IsFamilleArticlesEnabled;
            FamilleArticlesOpacity = IsFamilleArticlesEnabled ? 1.0 : 0.5;
        }
        #endregion
    }
}
