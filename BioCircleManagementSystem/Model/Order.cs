using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.Model
{
    class Order : INotifyPropertyChanged
    {
        #region Property
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion Property
        //private fields
        private int _orderID;
        private Customer _customer;
        private Machine _machine;



        //public properties
  


        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; OnPropertyChanged("OrderID"); }
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged("Customer"); }
        }

        public Machine Machine
        {
            get { return _machine; }
            set { _machine = value; OnPropertyChanged("Machine"); }
        }

        //Public constructor
        public Order()
        {
            Customer = new Customer();
            Machine = new Machine();
        }

       
        public void GetOrders()
        {
            DataManager.Instance.GetOrders("");
        }

        public void CreateOrder()
        {
            DataManager.Instance.CreateOrder(this);
        }

        public void SendOrder()
        {

        }

        public void Update()
        {
            DataManager.Instance.UpdateOrder("");
        }
    }
}
