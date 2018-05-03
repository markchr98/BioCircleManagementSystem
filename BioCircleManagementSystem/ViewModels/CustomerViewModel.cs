using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    public class CustomerViewModel:INotifyPropertyChanged
    {
        public Customer Customer { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }

        private static CustomerViewModel instance;
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Constructor 
        public CustomerViewModel()
        {            
            Customer = new Customer();
            Contacts = new ObservableCollection<Contact>();
        }
        public static CustomerViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CustomerViewModel();
                }                
                return instance;
            }
        }
        
        public void NewCustomer(string customerName, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity, string economicsCustomerNumber)
        {
            DataManager.Instance.CreateCustomer(new Customer(customerName, billingAddress, billingZipcode, billingCity, installationAddress, installationZipcode, installationCity, economicsCustomerNumber));
            
        }

        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        public void AddContact()
        {
            Contacts.Add(new Contact());
        }

        public void CreateCustomer()
        {
            //how da fuk we deal wit contacts
            Customer.CreateCustomer();
        }

        public List<Customer> GetCustomers(string keyword)
        {
            return DataManager.Instance.GetCustomers(keyword);
        }        

        public void NewContact(string name, int mobilephone, string email, int landline, int customerID)
        {
            DataManager.Instance.CreateContact(new Contact(name, mobilephone, email, landline, customerID));
        }

        public void DeleteCustomer(string customerID)
        {
            //Måske skal der laves noget vedd MachineID
            DataManager.Instance.DeleteCustomer(customerID);
        }

        public void DeleteContact(string customerID)
        {
            DataManager.Instance.DeleteContact(customerID);
        }

        internal void ClearCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
