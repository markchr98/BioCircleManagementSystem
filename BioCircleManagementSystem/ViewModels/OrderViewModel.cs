using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    class OrderViewModel
    {
        public static OrderViewModel instance;
        //Public constructor
        public OrderViewModel()
        {
           
        }
        public static OrderViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderViewModel();
                }
                return instance;
            }
        }
        public void NewOrder(int orderID, int customerID, int machineID)
        {
            DataManager.Instance.CreateOrder(new Order(orderID,DataManager.Instance.GetCustomer(customerID),DataManager.Instance.GetMachine(machineID)));
        }

        public List<Order> GetOrders(string keyword)
        {
            return DataManager.Instance.GetOrders(keyword);
        }
    }
}
