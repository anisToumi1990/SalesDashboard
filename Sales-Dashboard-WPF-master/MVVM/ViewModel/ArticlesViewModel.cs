using Sales_Dashboard.Core;
using Sales_Dashboard.MVVM.Model;
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

        public ICommand DeleteArticleCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateArticleCommand { get; set; }
        public ICommand CloseUpdateArticleCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddArticleCommand { get; set; }
        public ICommand CloseAddArticleCommand { get; set; }
        #endregion

        public ArticlesViewModel()
        {
            InitFocus();
            LoadArticles();
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
                }
                context.SaveChanges();
            }
            SwitchFocusUpdate();
        }
        private void CloseUpdateArticle(object obj)
        {
            LoadArticles();
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
        }
        private void InitFocus()
        {
            IsArticleAddPopup = false;
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
