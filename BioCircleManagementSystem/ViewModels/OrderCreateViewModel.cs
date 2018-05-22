using BioCircleManagementSystem.DataAccess;
using BioCircleManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.ViewModels
{
    class OrderCreateViewModel: INotifyPropertyChanged
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

        public Order Order { get; set; }

        private Machine _selectedMachine;
        public Customer SelectedCustomer { get; set; }

        public ObservableCollection<Customer> CustomerList { get; set; }
        
        public Machine SelectedMachine { get { return _selectedMachine; } set { _selectedMachine = value; OnPropertyChanged("SelectedMachine"); } }

        public ObservableCollection<Machine> MachineList { get; set; }

        public Liquid SelectedLiquid { get; set; }

        public ObservableCollection<Liquid> LiquidList { get; set; }
        public Filters SelectedFilters { get; set; }

        public ObservableCollection<Filters> FiltersList { get; set; }
        public Brush SelectedBrush { get; set; }

        public ObservableCollection<Brush> BrushList { get; set; }

        public Steeltop SelectedSteelTop { get; set; }

        public ObservableCollection<Steeltop> SteeltopList { get; set; }



        public OrderCreateViewModel()
        {
            Order = new Order();
            CustomerList = new ObservableCollection<Customer>(DataManager.Instance.GetCustomers(""));
            MachineList = new ObservableCollection<Machine>(DataManager.Instance.GetMachines(""));
            LiquidList = new ObservableCollection<Liquid>(DataManager.Instance.GetLiquids(""));
            FiltersList = new ObservableCollection<Filters>(DataManager.Instance.GetFilters(""));
            BrushList = new ObservableCollection<Brush>(DataManager.Instance.GetBrushes(""));
            SteeltopList = new ObservableCollection<Steeltop>(DataManager.Instance.GetSteeltops(""));
        }

        public void CreateOrder()
        {
            Order.CreateOrder();
        }
    }
}
