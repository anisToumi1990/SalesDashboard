using Sales_Dashboard.Core;
using Sales_Dashboard.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Linq;


namespace Sales_Dashboard.MVVM.ViewModel
{
    class ClientsViewModel : Core.ViewModel
    {
        #region Props and declarations
        private ObservableCollection<Client> _lstClients;
        public ObservableCollection<Client> LstClients
        {
            get { return _lstClients; }
            set
            {
                _lstClients = value;
                OnPropertyChanged(nameof(LstClients));
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private bool _isClientEditPopup;
        public bool IsClientEditPopup
        {
            get { return _isClientEditPopup; }
            set
            {
                _isClientEditPopup = value;
                OnPropertyChanged(nameof(IsClientEditPopup));
            }
        }

        private bool _isClientAddPopup;
        public bool IsClientAddPopup
        {
            get { return _isClientAddPopup; }
            set
            {
                _isClientAddPopup = value;
                OnPropertyChanged(nameof(IsClientAddPopup));
            }
        }

        private bool _isClientsEnabled;
        public bool IsClientsEnabled
        {
            get { return _isClientsEnabled; }
            set
            {
                _isClientsEnabled = value;
                OnPropertyChanged(nameof(IsClientsEnabled));
            }
        }

        private double _clientsOpacity;
        public double ClientsOpacity
        {
            get { return _clientsOpacity; }
            set
            {
                _clientsOpacity = value;
                OnPropertyChanged(nameof(ClientsOpacity));
            }
        }

        private Client _newClient;
        public Client NewClient
        {
            get { return _newClient; }
            set
            {
                _newClient = value;
                OnPropertyChanged(nameof(NewClient));
            }
        }

        public ICommand DeleteClientCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateClientCommand { get; set; }
        public ICommand CloseUpdateClientCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddClientCommand { get; set; }
        public ICommand CloseAddClientCommand { get; set; }

        #endregion

        public ClientsViewModel()
        {
            InitFocus();
            LoadClients();
            InstanciateCommands();
        }

        #region Loads
        public void LoadClients()
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                List<Client> clients = context.Clients.ToList();
                LstClients = new ObservableCollection<Client>(clients);
            }
        }
        #endregion

        #region Crud Functions
        private void Delete(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var clientToDelete = obj as Client;
                context.Clients.Remove(clientToDelete);
                context.SaveChanges();
                LstClients.Remove(clientToDelete);
            }
        }
        private void Update(object obj)
        {
            SelectedClient = obj as Client;
            SwitchFocusUpdate();
        }
        private void UpdateClient(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                var cl = context.Clients.FirstOrDefault(e => e.Id == SelectedClient.Id);
                if (cl != null)
                {
                    cl.Code = SelectedClient.Code;
                    cl.Nom = SelectedClient.Nom;
                    cl.Adresse = SelectedClient.Adresse;
                    cl.Tel = SelectedClient.Tel;
                    cl.Gsm = SelectedClient.Gsm;
                    cl.Email = SelectedClient.Email;
                    cl.MatriculeFiscal = SelectedClient.MatriculeFiscal;
                }
                context.SaveChanges();
            }
            SwitchFocusUpdate();
        }
        private void CloseUpdateClient(object obj)
        {
            LoadClients();
            SwitchFocusUpdate();
        }
        private void Add(object obj)
        {
            NewClient = new Client();
            SwitchFocusAdd();
        }
        private void AddClient(object obj)
        {
            using (StockFacturationContext context = new StockFacturationContext())
            {
                context.Clients.Add(NewClient);
                context.SaveChanges();
            }
            LstClients.Add(NewClient);
            NewClient = new Client();
            SwitchFocusAdd();
        }
        private void CloseAddClient(object obj)
        {
            NewClient = new Client();
            SwitchFocusAdd();
        }
        #endregion

        #region Utilities
        private void InstanciateCommands()
        {
            DeleteClientCommand = new RelayCommand(Delete, (s) => true);
            UpdateCommand = new RelayCommand(Update, (s) => true);
            UpdateClientCommand = new RelayCommand(UpdateClient, (s) => true);
            CloseUpdateClientCommand = new RelayCommand(CloseUpdateClient, (s) => true);
            AddCommand = new RelayCommand(Add, (s) => true);
            AddClientCommand = new RelayCommand(AddClient, (s) => true);
            CloseAddClientCommand = new RelayCommand(CloseAddClient, (s) => true);
        }
        private void InitFocus()
        {
            IsClientAddPopup = false;
            IsClientEditPopup = false;
            IsClientsEnabled = true;
            ClientsOpacity = 1.0;
        }
        private void SwitchFocusAdd()
        {
            SwitchFocus();
            IsClientAddPopup = !IsClientAddPopup;
        }
        private void SwitchFocusUpdate()
        {
            SwitchFocus();
            IsClientEditPopup = !IsClientEditPopup;
        }
        private void SwitchFocus()
        {
            IsClientsEnabled = !IsClientsEnabled;
            ClientsOpacity = IsClientsEnabled ? 1.0 : 0.5;
        }
        #endregion
    }
}
