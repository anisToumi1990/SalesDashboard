using Sales_Dashboard.Core;
using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Sales_Dashboard.MVVM.ViewModel
{
    class ArticlesViewModel : Core.ViewModel
    {
        #region Props and declarations
        private ObservableCollection<Article> _lstArticles;
        public ObservableCollection<Article> LstArticles
        {
            get { return _lstArticles; }
            set 
            { 
                _lstArticles = value;
                OnPropertyChanged(nameof(LstArticles));
            }
        }

        private ObservableCollection<Famille> _lstFamilleArticles;
        public ObservableCollection<Famille> LstFamilleArticles
        {
            get { return _lstFamilleArticles; }
            set
            {
                _lstFamilleArticles = value;
                OnPropertyChanged(nameof(_lstFamilleArticles));
            }
        }

        private ObservableCollection<Fournisseur> _lstFournisseurs;
        public ObservableCollection<Fournisseur> LstFournisseurs
        {
            get { return _lstFournisseurs; }
            set
            {
                _lstFournisseurs = value;
                OnPropertyChanged(nameof(_lstFournisseurs));
            }
        }

        private Article _selectedArticle;
        public Article SelectedArticle
        {
            get { return _selectedArticle; }
            set 
            { 
                _selectedArticle = value;
                OnPropertyChanged(nameof(SelectedArticle));
            }
        }

        private bool _isArticleEditPopup;
        public bool IsArticleEditPopup
        {
            get { return _isArticleEditPopup; }
            set 
            { 
                _isArticleEditPopup = value;
                OnPropertyChanged(nameof(IsArticleEditPopup));
            }
        }

        private Article _newArticle;
        public Article NewArticle
        {
            get { return _newArticle; }
            set
            {
                _newArticle = value;
                OnPropertyChanged(nameof(NewArticle));
            }
        }

        private bool _isArticleAddPopup;
        public bool IsArticleAddPopup
        {
            get { return _isArticleAddPopup; }
            set
            {
                _isArticleAddPopup = value;
                OnPropertyChanged(nameof(IsArticleAddPopup));
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

        private bool _isArticlesEnabled;
        public bool IsArticlesEnabled
        {
            get { return _isArticlesEnabled; }
            set
            {
                _isArticlesEnabled = value;
                OnPropertyChanged(nameof(IsArticlesEnabled));
            }
        }

        private double _articlesOpacity;
        public double ArticlesOpacity
        {
            get { return _articlesOpacity; }
            set
            {
                _articlesOpacity = value;
                OnPropertyChanged(nameof(ArticlesOpacity));
            }
        }

        private string _filterFamille;
        public string FilterFamille
        {
            get { return _filterFamille; }
            set 
            { 
                _filterFamille = value;
                OnPropertyChanged(nameof(FilterFamille));
            }
        }

        private string _filterFournisseur;
        public string FilterFournisseur
        {
            get { return _filterFournisseur; }
            set 
            { 
                _filterFournisseur = value;
                OnPropertyChanged(nameof(FilterFournisseur));
            }
        }

        public ICommand DeleteArticleCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateArticleCommand { get; set; }
        public ICommand CloseUpdateArticleCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddArticleCommand { get; set; }
        public ICommand CloseAddArticleCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand CancelFilterCommand { get; set; }

        #endregion

        public ArticlesViewModel()
        {
            InitFocus();
            LoadArticles();
            LoadFamilleArticles();
            LoadFournisseurArticles();
            InstanciateCommands();
        }

        #region Crud Functions
        public void LoadArticles()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Article> articles = context.Articles.ToList();
                LstArticles = new ObservableCollection<Article>(articles);
            }
        }
        public void LoadFamilleArticles()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Famille> familleArticles = context.Familles.ToList();
                LstFamilleArticles = new ObservableCollection<Famille>(familleArticles);
            }
        }
        public void LoadFournisseurArticles()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Fournisseur> fournisseurs = context.Fournisseurs.ToList();
                LstFournisseurs = new ObservableCollection<Fournisseur>(fournisseurs);
            }
        }
        private void Delete(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var articleToDelete = obj as Article;
                context.Articles.Remove(articleToDelete);
                context.SaveChanges();
                LstArticles.Remove(articleToDelete);
            }
        }
        private void Update(object obj)
        {
            SelectedArticle = obj as Article;
            SwitchFocusUpdate();
        }
        private void UpdateArticle(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var art = context.Articles.FirstOrDefault(e => e.Id == SelectedArticle.Id);
                if (art != null)
                {
                    art.Designation = SelectedArticle.Designation;
                    art.CodeFamille = SelectedArticle.CodeFamille;
                    art.CodeFournisseur = SelectedArticle.CodeFournisseur;
                    art.Code = SelectedArticle.Code;
                    art.Unite = SelectedArticle.Unite;
                    art.PrixAchat = SelectedArticle.PrixAchat;
                    art.PrixVenteHt = SelectedArticle.PrixVenteHt;
                    art.PrixTtc = SelectedArticle.PrixTtc;
                }
                context.SaveChanges();
            }
            SwitchFocusUpdate();
        }
        private void CloseUpdateArticle(object obj)
        {
            LoadArticles();
            Filter(null);
            SwitchFocusUpdate();
        }
        private void Add(object obj)
        {
            NewArticle = new Article();
            SwitchFocusAdd();
        }
        private void AddArticle(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                context.Articles.Add(NewArticle);
                context.SaveChanges();
            }
            LstArticles.Add(NewArticle);
            NewArticle = new Article();
            SwitchFocusAdd();
        }
        private void CloseAddArticle(object obj)
        {
            NewArticle = new Article();
            SwitchFocusAdd();
        }
        private void Filter(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                if (FilterFamille != null && FilterFournisseur != null)
                {
                    List<Article> articles = context.Articles.Where(x => (x.CodeFamille == FilterFamille && x.CodeFournisseur == FilterFournisseur)).ToList();
                    LstArticles = new ObservableCollection<Article>(articles);
                }
                else if (FilterFamille != null)
                {
                    List<Article> articles = context.Articles.Where(x => x.CodeFamille == FilterFamille).ToList();
                    LstArticles = new ObservableCollection<Article>(articles);
                }
                else if (FilterFournisseur != null)
                {
                    List<Article> articles = context.Articles.Where(x => x.CodeFournisseur == FilterFournisseur).ToList();
                    LstArticles = new ObservableCollection<Article>(articles);
                }
            }
        }
        private void CancelFilter(object obj)
        {
            FilterFamille = null;
            FilterFournisseur = null;
            LoadArticles();
        }
        #endregion

        #region Utilities
        private void InstanciateCommands()
        {
            DeleteArticleCommand = new RelayCommand(Delete, (s) => true);
            UpdateCommand = new RelayCommand(Update, (s) => true);
            UpdateArticleCommand = new RelayCommand(UpdateArticle, (s) => true);
            CloseUpdateArticleCommand = new RelayCommand(CloseUpdateArticle, (s) => true);
            AddCommand = new RelayCommand(Add, (s) => true);
            AddArticleCommand = new RelayCommand(AddArticle, (s) => true);
            CloseAddArticleCommand = new RelayCommand(CloseAddArticle, (s) => true);
            FilterCommand = new RelayCommand(Filter, (s) => true);
            CancelFilterCommand = new RelayCommand(CancelFilter, (s) => true);
        }
        private void InitFocus()
        {
            IsArticleAddPopup = false;
            IsFamilleArticleAddPopup = false;
            IsArticleEditPopup = false;
            IsArticlesEnabled = true;
            ArticlesOpacity = 1.0;
        }
        private void SwitchFocusAdd()
        {
            SwitchFocus();
            IsArticleAddPopup = !IsArticleAddPopup;
        }
        private void SwitchFocusUpdate()
        {
            SwitchFocus();
            IsArticleEditPopup = !IsArticleEditPopup;
        }
        private void SwitchFocus()
        {
            IsArticlesEnabled = !IsArticlesEnabled;
            ArticlesOpacity = IsArticlesEnabled ? 1.0 : 0.5;
        }
        #endregion
    }
}
