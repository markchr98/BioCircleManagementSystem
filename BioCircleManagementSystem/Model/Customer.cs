using BioCircleManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        private ObservableCollection<Department> _departments;
        private string _economicsCustomerNumber;         

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
        public ObservableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged("Departments");
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

        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Public constructors
        public Customer()
        {
            Contacts = new ObservableCollection<Contact>();
            Departments = new ObservableCollection<Department>();
        }
        public Customer(string customerName, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity, string economicsCustomerNumber)
        {
            _customerName = customerName;
            _billingAddress = billingAddress;
            _billingZipcode = billingZipcode;
            _billingCity = billingCity;
            _economicsCustomerNumber = economicsCustomerNumber;
        }

        //Methods
        public void CreateCustomer()
        {
            DataManager.Instance.CreateCustomer(this);
            CustomerID = DataManager.Instance.GetNewestCustomerID();
            foreach (Contact c in Contacts)
            {
                c.Customer = this;
                c.CreateContact();                
            }
            foreach(Department d in Departments)
            {
                d.Customer = this;
                d.CreateDepartment();
            }
        }

        internal void UpdateCustomer()
        {
            DataManager.Instance.UpdateCustomer(this);
        }

        public void DeleteCustomer()
        {
            DataManager.Instance.DeleteCustomer(this);
        }

        public void RemoveContact(Contact deleteme)
        {
            Contacts.Remove(deleteme);
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }
        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void DeleteDepartment(Department deleteme)
        {
            Departments.Remove(deleteme);
        }


    }
}
