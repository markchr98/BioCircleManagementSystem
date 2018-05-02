using System;
using System.Collections.Generic;
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
        public Customer _customer = new Customer();       
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
        
        public void NewCustomer(string customerName, string billingAddress, int billingZipcode, string billingCity, string installationAddress, int installationZipcode, string installationCity, int economicsCustomerNumber)
        {
            DataManager.Instance.CreateCustomer(new Customer(customerName, billingAddress, billingZipcode, billingCity, installationAddress, installationZipcode, installationCity, economicsCustomerNumber));
            
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
        
    }
}
