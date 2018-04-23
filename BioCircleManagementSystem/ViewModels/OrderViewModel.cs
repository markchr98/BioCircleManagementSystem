using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    class OrderViewModel
    {        
        //Constructor
        public OrderViewModel()
        {
           
        }

        public void NewOrder(string orderID,string customerID, string machineID)
        {
            DataManager.Instance.CreateOrder(new Order(orderID,DataManager.Instance.GetCustomer(customerID),DataManager.Instance.GetMachine(machineID)));
        }
    }
}
