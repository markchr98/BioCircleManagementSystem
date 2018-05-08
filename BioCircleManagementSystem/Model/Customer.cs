using BioCircleManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string _billingZipcode;
        private string _billingCity;
        private string _installationAddress;
        private string _installationZipcode;
        private string _installationCity;
        private ObservableCollection<Contact> _contacts;
        private string _economicsCustomerNumber;

        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
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
        public string BillingZipcode
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
        public string InstallationZipcode
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

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        public string EconomicsCustomerNumber
        {
            get { return _economicsCustomerNumber; }
            set
            {
                _economicsCustomerNumber = value;
                OnPropertyChanged("EconomicsCustomerNumber");
            }
        }      

        //Public constructors
        public Customer()
        {
            Contacts = new ObservableCollection<Contact>();
        }
        public Customer(string customerName, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity, string economicsCustomerNumber)
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
            foreach(Contact c in Contacts)
            {
                c.CreateContact();                
            }
        }

        public void EditCustomer(Customer customer)
        {
            DataManager.Instance.UpdateCustomer(customer);

        }

        public void DeleteCustomer()
        {

        }
    }
}
