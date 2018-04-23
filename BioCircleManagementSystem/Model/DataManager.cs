using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class DataManager
    {
        private static DataManager instance;
        
        private DataManager() { }

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        public void CreateOrder(Order order)
        {

        }

        public void GetOrder(int orderID)
        {

        }

        public void UpdateOrder(Order order)
        {

        }

        public void CreateCustomer(Customer customer)
        {

        }

        public void GetCustomer(Customer customer)
        {

        }

        public void UpdateCustomer(Customer customer)
        {

        }
    }
}
