using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class DataManager
    {
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

        public Order GetOrder(string orderID)
        {
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

        public void UpdateCustomer(string customerID)
        {
            throw new NotImplementedException();
        }

        public void CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(string contactMobilephone)
        {
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
        

        public void UpdateMachine(string machineID)
        {
            throw new NotImplementedException();
        }
    }
}
