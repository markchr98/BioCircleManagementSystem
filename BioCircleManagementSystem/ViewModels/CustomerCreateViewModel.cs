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
    public class CustomerCreateViewModel:INotifyPropertyChanged
    {
       
        public Customer Customer { get; set; }                
        
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
        public CustomerCreateViewModel()
        {            
            Customer = new Customer();            
        }       
        

        public void RemoveContact(Contact contact)
        {
            Customer.RemoveContact(contact);
        }

        public void AddContact()
        {
            Customer.AddContact(new Contact());
        }

        public void CreateCustomer()
        {
            
            Customer.CreateCustomer();
        }

        public List<Customer> GetCustomers(string keyword)
        {
            return DataManager.Instance.GetCustomers(keyword);
        }

        public void ClearCustomer()
        {
            Customer.CustomerName = "";
            Customer.EconomicsCustomerNumber = "";
            Customer.BillingAddress = "";
            Customer.BillingCity = "";
            Customer.BillingZipcode = "";
            Customer.InstallationAddress = "";
            Customer.InstallationCity = "";
            Customer.InstallationZipcode = "";
            Customer.Contacts.Clear();
            
        }

        internal void AddDepartment()
        {
            Customer.AddDepartment(new Department());
        }

        internal void RemoveDepartment(Department deleteme)
        {
            Customer.DeleteDepartment(deleteme);
        }
    }
}
