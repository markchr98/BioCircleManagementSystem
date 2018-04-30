﻿using System;
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
        //Public constructor
        public OrderViewModel()
        {
           
        }

        public void NewOrder(string orderID, string customerID, string machineID)
        {
            DataManager.Instance.CreateOrder(new Order(orderID,DataManager.Instance.GetCustomer(customerID),DataManager.Instance.GetMachine(machineID)));
        }

        public List<Order> GetOrders(string keyword)
        {
            return DataManager.Instance.GetOrders(keyword);
        }
    }
}
