using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class Order
    {
        //private fields
        private string _orderID;
        private Customer _customer;
        private Machine _machine;

        //public properties
        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public Machine Machine
        {
            get { return _machine; }
            set { _machine = value; }
        }

        //Public constructor
        public Order()
        {
        }

        public Order(string orderID, Customer customer, Machine machine)
        {
            _orderID = orderID;
            _customer = customer;
            _machine = machine;
        }    
    }
}
