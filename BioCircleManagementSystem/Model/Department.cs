using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.Model
{
    public class Department
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion Property
        private string _installationAddress;
        private string _installationZipcode;
        private string _installationCity;
        private string _canBringLiquid; //should be bool
        private Customer _customer;
        private ObservableCollection<Contact> _contacts;
        private Machine _machine;

      

        public Machine Machine
        {
            get { return _machine; }
            set { _machine = value; }
        }


               

        public string InstallationAddress
        {
            get
            {
                return _installationAddress;
            }
            set
            {
                _installationAddress = value; OnPropertyChanged("InstallationAddress");
            }
        }
        public string InstallationCity
        {
            get
            {
                return _installationCity;
            }
            set
            {
                _installationCity = value; OnPropertyChanged("InstallationCity");
            }
        }
        public string InstallationZipcode
        {
            get
            {
                return _installationZipcode;
            }
            set
            {
                _installationZipcode = value; OnPropertyChanged("InstallationZipcode");
            }
        }
        public string CanBringLiquid
        {
            get
            {
                return _canBringLiquid;
            }
            set
            {
                _canBringLiquid = value; OnPropertyChanged("CanBringLiquid");
            }
        }
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value; OnPropertyChanged("Customer");
            }
        }

        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        public Department()
        {
            Customer = new Customer();
        }
       
        public void CreateDepartment()
        {
            DataManager.Instance.CreateDepartment(this);
        }
    }
}
