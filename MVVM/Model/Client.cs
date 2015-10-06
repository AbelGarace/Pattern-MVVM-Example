namespace Pattern.MVVM_Example.MVVM.Model
{
    class Client : NotifyBase
    {
        #region Atributos
            private int id;
            private string name;
            private string lastname;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { if (id!= value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                    OnPropertyChanged("DisplayName");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set { if(name!= value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("DisplayName");
                }
            }
        }

        public string LastName
        {
            get { return lastname; }
            set { if(lastname!= value)
                {
                    lastname = value;
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("DisplayName");
                }
            }
        }

        public string DisplayName
        {
            get { return Id + "-" + Name + "-" + LastName; }
        }
        #endregion
    }
}
