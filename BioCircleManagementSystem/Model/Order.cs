using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class Order
    {
        private int _orderID;
        private Customer _customer;

        public Order(int orderID, Customer customer)
        {
            _orderID = orderID;
            _customer = customer;
        }
    }
}
