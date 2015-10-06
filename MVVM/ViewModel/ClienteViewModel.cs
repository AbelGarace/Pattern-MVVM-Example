using Pattern.MVVM_Example.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Pattern.MVVM_Example.MVVM.ViewModel
{
    class ClienteViewModel : ObservableCollection<Client>, INotifyPropertyChanged
    {
        #region Atributos
        private int selectedIndex;
        private int id;
        private string name;
        private string lastName;
        private ICommand addClientCommand;
        private ICommand clearCommand;
        private ICommand deleteCommand;
        #endregion

        #region Propiedades
        public int SelectedIndexOfCollection
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");
                OnPropertyChanged("Id");
                OnPropertyChanged("Name");
                OnPropertyChanged("LastName");
            }
        }

        public int Id
        {
            get { if (this.SelectedIndexOfCollection > -1) { return this.Items[SelectedIndexOfCollection].Id; } else { return id; } }
            set { if (this.SelectedIndexOfCollection > -1) { this.Items[this.SelectedIndexOfCollection].Id = value; } else { id = value; } OnPropertyChanged("Id"); }
        }

        public string Name
        {
            get { if (this.SelectedIndexOfCollection > -1) { return this.Items[SelectedIndexOfCollection].Name; } else { return name; } }
            set { if (this.SelectedIndexOfCollection > -1) { this.Items[this.SelectedIndexOfCollection].Name = value; } else { name = value; } OnPropertyChanged("Name"); }
        }

        public string LastName
        {
            get { if (this.SelectedIndexOfCollection > -1) { return this.Items[SelectedIndexOfCollection].LastName; } else { return lastName; } }
            set { if (this.SelectedIndexOfCollection > -1) { this.Items[this.SelectedIndexOfCollection].LastName = value; } else { lastName = value; } OnPropertyChanged("LastName"); }
        }

        public ICommand AddClientCommand
        {
            get { return addClientCommand; }
            set { addClientCommand = value; }
        }

        public ICommand ClearCommand
        {
            get { return clearCommand; }
            set { clearCommand = value; }
        }

        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }
        #endregion

        #region Constructores

        public ClienteViewModel()
        {
            Client clClient1 = new Client() { Id = 1, Name = "Leo", LastName = "Messi" };
            this.Add(clClient1);
            Client clClient2 = new Client() { Id = 2, Name = "Cristiano", LastName = "Ronaldo" };
            this.Add(clClient2);
            Client clClient3 = new Client() { Id = 3, Name = "Fernando", LastName = "Torres" };
            this.Add(clClient3);

            AddClientCommand = new CommandBase(param => this.AddClient());
            ClearCommand = new CommandBase(new Action<Object>(ClearClient));           
        }

        #endregion


        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Funciones

        private void AddClient()
        {
            Client vlClient = new Client() { Id = Id, Name = Name, LastName = LastName };
            this.Add(vlClient);
        }

        private void ClearClient(object obj)
        {
            SelectedIndexOfCollection = -1;
            Id = 0;
            Name = "";
            LastName = "";
        }

       
        #endregion
    }
}
