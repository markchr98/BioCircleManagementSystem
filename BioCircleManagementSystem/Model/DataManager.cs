using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class DataManager
    {
        //private instance
        private static DataManager _instance;
        
        private DataManager() { }        

        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        
        public List<Order> GetOrders(string keyword)
        {
            //if key not null filter orders
            //return orders
            throw new NotImplementedException();
        }

        public void UpdateOrder(string orderID)
        {
            throw new NotImplementedException();
        }

        public void CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string customerID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers(string keyword)
        {
            //if key not null filter customers
            //return customers
            throw new NotImplementedException();
        }

        public void UpdateCustomer(string customerID)
        {
            throw new NotImplementedException();
        }

        public void CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContacts(string keyword)
        {
            //if key not null filter contacts
            //return contacts
            throw new NotImplementedException();
        }

        public void UpdateContact(string contactMobilephone)
        {
            throw new NotImplementedException();
        }

        public void CreateMachine(Machine machine)
        {
            throw new NotImplementedException();
        }

        public Machine GetMachine(string machineID)
        {
            throw new NotImplementedException();
        }

        public List<Machine> GetMachines(string keyword)
        {
            //test
            //if key not null filter machines
            //return machines
            throw new NotImplementedException();
        }
        

        public void UpdateMachine(string machineID)
        {
            throw new NotImplementedException();
        }
    }
}
