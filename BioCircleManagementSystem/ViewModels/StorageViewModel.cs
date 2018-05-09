using BioCircleManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BioCircleManagementSystem.ViewModels
{
    internal class StorageViewModel : INotifyPropertyChanged
    {
        public Machine machine { get; set; }
        //Constructor

        private static StorageViewModel _instance;

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


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static StorageViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StorageViewModel();
                }
                return _instance;
            }
        }

        public StorageViewModel()
        {
            List<Machine> machines = DataManager.Instance.GetMachines("");
            _machines = new ObservableCollection<Machine>(machines);
            machine = new Machine();
        }

        // Gets the Machine instance (this is public accessable)
        public Machine Machine
        {
            get
            {
                return machine;
            }
        }

        public void CreateMachine(string vesselNo, string vesselType, string machineNo, string controlBoxNo)
        {
            DataManager.Instance.CreateMachine(new Machine(vesselNo, vesselType, machineNo, controlBoxNo));
        }

        public void SearchMachines(string keyword)
        {
            Machines = new ObservableCollection<Machine>(DataManager.Instance.GetMachines(keyword));
        }

        public void CreateMachine()
        {
            Machine.CreateMachine();
        }
        public List<Machine> GetMachines(string keyword)
        {
            return DataManager.Instance.GetMachines(keyword);
        }

        public void ClearMachine()
        {
            Machine.VesselType = "";
            Machine.VesselNo = "";
            Machine.MachineNo = "";
            Machine.ControlBoxNo = "";
            Machine.InstallationDate = "";
            Machine.Wheels = "";
            Machine.InoxGrid = "";
            Machine.Lid = "";
            Machine.SteelTop = null;
            Machine.CanBringLiquid = "";
        }

    }
}
