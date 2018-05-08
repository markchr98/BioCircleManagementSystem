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
        public Customer SelectedCustomer { get; set; }

        public ObservableCollection<Customer> CustomerList { get; set; }

        public Machine SelectedMachine { get; set; }

        public List<Machine> MachineList = new List<Machine>();

        public Liquid SelectedLiquid { get; set; }

        public List<Liquid> LiquidList = new List<Liquid>();
        public Filters SelectedFilters { get; set; }

        public List<Filters> FiltersList = new List<Filters>();
        public Brush SelectedBrush { get; set; }

        public List<Filters> BrushList = new List<Filters>();

        public OrderCreateViewModel()
        {
            CustomerList = new ObservableCollection<Customer>(DataManager.Instance.GetCustomers(""));
        }

    }
}
