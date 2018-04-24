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
        private static List<Contact> contacts;
        private static CustomerViewModel instance;
        //Constructor
        private CustomerViewModel()
        {            
            contacts = new List<Contact>();
        }
        public static CustomerViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CustomerViewModel();
                }
                //Ensure contacts is empty when entering page
                contacts = new List<Contact>();
                return instance;
            }
        }
        
        public void NewCustomer(string customerName, int customerID, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity)
        {
            DataManager.Instance.CreateCustomer(new Customer(customerName,customerID,billingAddress,billingZipcode,billingCity,installationAddress,installationZipcode,installationCity, contacts));

        }

        public List<Customer> GetCustomers(string keyword)
        {
            return DataManager.Instance.GetCustomers(keyword);
        }

        public void AddContact(string name, string mobilephone, string email, string landline, string customerID)
        {
            contacts.Add(new Contact(name, mobilephone, email, landline, customerID));
        }

        public void RemoveContactAt(int position)
        {
            contacts.Remove(contacts[position]);
        }
    }
}
