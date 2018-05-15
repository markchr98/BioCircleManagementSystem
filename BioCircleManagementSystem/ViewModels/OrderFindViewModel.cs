using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.ViewModels
{
    class OrderFindViewModel : INotifyPropertyChanged
    {
        private Order _selectedOrder;


        public Order SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        private static OrderFindViewModel _instance;

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private OrderFindViewModel()
        {
            List<Order> orders = DataManager.Instance.GetOrders("");
            _orders = new ObservableCollection<Order>(orders);
        }

        public static OrderFindViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderFindViewModel();
                }
                return _instance;
            }
        }

        public void SearchOrders(string keyword)
        {
            Orders = new ObservableCollection<Order>(DataManager.Instance.GetOrders(keyword));
        }


        public void UpdateCustomer()
        {
            //_selectedOrder
        }
        public void DeleteCustomer()
        {
            //SelectedOrder
        }
    }
}
