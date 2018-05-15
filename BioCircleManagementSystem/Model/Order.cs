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
        private Liquid _liquid;
        private Brush _brush;
        private Filters _filters;
        private Service _service;


        //public properties
        public Service Service
        {
            get { return _service; }
            set { _service = value; }
        }


        public Filters Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }


        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }


        public Liquid Liquid
        {
            get { return _liquid; }
            set { _liquid = value; }
        }


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
            Filters = new Filters();
            Liquid = new Liquid();
            Brush = new Brush();
            Service = new Service();
        }

        public Order(int orderID, Customer customer, Machine machine)
        {
            _orderID = orderID;
            _customer = customer;
            _machine = machine;
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
