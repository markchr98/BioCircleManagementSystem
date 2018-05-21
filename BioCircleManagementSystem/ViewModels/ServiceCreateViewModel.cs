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
    class ServiceCreateViewModel : INotifyPropertyChanged
    {
        private Machine selectedMachine;

        public Machine SelectedMachine
        {
            get
            {
                return selectedMachine;
            }
            set
            {
                selectedMachine = value;
                OnPropertyChanged("SelectedMachine");
            }
        }

        private Service service;

        public Service Service
        {
            get
            {
                return service;
            }
            set
            {
                service = value;
                OnPropertyChanged("Service");
            }
        }

        private ObservableCollection<Machine> machines;

        public ObservableCollection<Machine> Machines
        {
            get
            {
                return machines;
            }
            set
            {
                machines = value;
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

        //Constructor 
        public ServiceCreateViewModel()
        {
            selectedMachine = new Machine();
            service = new Service();
            List<Machine> DataList = DataManager.Instance.GetMachines("");
            machines = new ObservableCollection<Machine>(DataList);
        }


        public void CreateService()
        {
            Service.CreateService();
        }

        public List<Service> GetServices(string keyword)
        {
            return DataManager.Instance.GetServices(keyword);
        }

        public void ClearService()
        {
            Service.Smell = "";
            Service.Temperature = 0;
            Service.PHValue = 0;
            Service.CleaningEffect = "";
            Service.Arrival = 0;
            Service.Depature = 0;
            Service.Machine.MachineNo = "";
            Service.Technician.FullName = "";
            Service.WeekNumber = (DateTime.Now.DayOfYear / 7) + 1;
        }
    }
}
