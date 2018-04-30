using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    public class CustomerViewModel
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
        
        public void NewCustomer(string customerName, string billingAddress, int billingZipcode, string billingCity, string installationAddress, int installationZipcode, string installationCity, int economicsCustomerNumber)
        {
            DataManager.Instance.CreateCustomer(new Customer(customerName, billingAddress, billingZipcode, billingCity, installationAddress, installationZipcode, installationCity, economicsCustomerNumber));
            
        }

        public List<Customer> GetCustomers(string keyword)
        {
            return DataManager.Instance.GetCustomers(keyword);
        }

        //used when creating contacts for new customer
        public int GetLastCustomerID()
        {
           return DataManager.Instance.GetLastCustomerID();
        }

        public void NewContact(string name, int mobilephone, string email, int landline, int customerID)
        {
            DataManager.Instance.CreateContact(new Contact(name, mobilephone, email, landline, customerID));
        }
    }
}
