using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    class CustomerViewModel
    {       
        private static CustomerViewModel instance;
        //Constructor
        private CustomerViewModel()
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
        
        public void NewCustomer(string customerName, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity)
        {
            DataManager.Instance.CreateCustomer(new Customer(customerName, billingAddress, billingZipcode, billingCity, installationAddress, installationZipcode, installationCity));
            
        }

        public List<Customer> GetCustomers(string keyword)
        {
            return DataManager.Instance.GetCustomers(keyword);
        }

        public void NewContact(string name, string mobilephone, string email, string landline, string customerID)
        {
            DataManager.Instance.CreateContact(new Contact(name, mobilephone, email, landline, customerID));
        }       
    }
}
