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

        }

        public Order GetOrder(string orderID)
        {

        }

        public void UpdateOrder(string orderID)
        {

        }

        public void CreateCustomer(Customer customer)
        {

        }

        public Customer GetCustomer(string customerID)
        {

        }

        public void UpdateCustomer(string customerID)
        {

        }

        public void CreateContact(Contact contact)
        {

        }

        public Contact GetContact(string contactMobilephone)
        {

        }

        public void UpdateContact(string contactMobilephone)
        {

        }

        public void CreateMachine(Machine machine)
        {

        }

        public Machine GetMachine(string machineID)
        {
            
        }
        

        public void UpdateMachine(string machineID)
        {

        }
    }
}
