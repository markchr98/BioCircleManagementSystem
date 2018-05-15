using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    internal class StorageFindViewModel : INotifyPropertyChanged
    {
        private StorageFindViewModel()
        {
            Machines = new ObservableCollection<Machine>(DataManager.Instance.GetMachines(""));
            SteeltopList = new ObservableCollection<Steeltop>(DataManager.Instance.GetSteeltops(""));
            FiltersList = new ObservableCollection<Filters>(DataManager.Instance.GetFilters(""));
            BrushList = new ObservableCollection<Brush>(DataManager.Instance.GetBrushes(""));
            LiquidList = new ObservableCollection<Liquid>(DataManager.Instance.GetLiquids(""));
            StatusList = new ObservableCollection<Status>(DataManager.Instance.GetStatus(""));

        }
        public Status SelectedStatus { get; set; }

        public ObservableCollection<Status> StatusList { get; set; }

        public Liquid SelectedLiquid { get; set; }

        public ObservableCollection<Liquid> LiquidList { get; set; }
        public Brush SelectedBrush { get; set; }

        public ObservableCollection<Brush> BrushList { get; set; }
        public Steeltop SelectedSteelTop { get; set; }

        public ObservableCollection<Steeltop> SteeltopList { get; set; }

        public Filters SelectedFilters { get; set; }

        public ObservableCollection<Filters> FiltersList { get; set; }

        private Machine _selectedMachine;

        public Machine SelectedMachine
        {
            get
            {
                return _selectedMachine;
            }
            set
            {
                _selectedMachine = value;
                OnPropertyChanged("SelectedMachine");
            }
        }
        private ObservableCollection<Machine> _machines;
        public ObservableCollection<Machine> Machines
        {
            get { return _machines; }
            set
            {
                _machines = value;
                OnPropertyChanged("Machines");
            }
        }
        public void SearchMachines(string keyword)
        {
            Machines = new ObservableCollection<Machine>(DataManager.Instance.GetMachines(keyword));
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

        private static StorageFindViewModel _instance;
        public static StorageFindViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StorageFindViewModel();
                }
                return _instance;
            }
        }

        public void UpdateMachine()
        {
            _selectedMachine.UpdateMachine();
        }
    }
}
