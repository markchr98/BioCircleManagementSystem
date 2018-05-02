using BioCircleManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    public class Customer : INotifyPropertyChanged
    {
         //Private fields
        private string _customerName;
        private int _customerID;
        private string _billingAddress;
        private int _billingZipcode;
        private string _billingCity;
        private string _installationAddress;
        private int _installationZipcode;
        private string _installationCity;
        private List<Contact> _contacts;
        private int _economicsCustomerNumber;

        public List<Contact> contactList;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Public properties
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }
        public string BillingAddress
        {
            get { return _billingAddress; }
            set
            {
                _billingAddress = value;
                OnPropertyChanged("BillingAddress");
            }
        }
        public int BillingZipcode
        {
            get { return _billingZipcode; }
            set
            {
                _billingZipcode = value;
                OnPropertyChanged("BillingZipcode");
            }
        }
        public string BillingCity
        {
            get { return _billingCity; }
            set
            {
                _billingCity = value;
                OnPropertyChanged("BillingCity");
            }
        }
        public string InstallationAddress
        {
            get { return _installationAddress; }
            set
            {
                _installationAddress = value;
                OnPropertyChanged("InstallationAddress");
            }
        }
        public int InstallationZipcode
        {
            get { return _installationZipcode; }
            set
            {
                _installationZipcode = value;
                OnPropertyChanged("InstallationZipcode");
            }
        }
        public string InstallationCity
        {
            get { return _installationCity; }
            set
            {
                _installationCity = value;
                OnPropertyChanged("InstallationCity");
            }
        }

        public List<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        public int EconomicsCustomerNumber
        {
            get { return _economicsCustomerNumber; }
            set
            {
                _economicsCustomerNumber = value;
            }
        }

        //Public constructors
        public Customer()
        {
            contactList = new List<Contact>();
        }
        public Customer(string customerName, string billingAddress, int billingZipcode, string billingCity, string installationAddress, int installationZipcode, string installationCity, int economicsCustomerNumber)
        {
            _customerName = customerName;
            _billingAddress = billingAddress;
            _billingZipcode = billingZipcode;
            _billingCity = billingCity;
            _installationAddress = installationAddress;
            _installationZipcode = installationZipcode;
            _installationCity = installationCity;
            _economicsCustomerNumber = economicsCustomerNumber;
        }

        public void CreateCustomer()
        {
            DataManager.Instance.CreateCustomer(this);            
            foreach(Contact c in contactList)
            {
                c.CreateContact();                
            }
        }
    }
}
