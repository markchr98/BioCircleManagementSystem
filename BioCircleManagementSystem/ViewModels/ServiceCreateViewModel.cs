using System;
using System.Collections.Generic;
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
        public Service Service { get; set; }

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
            Service = new Service();
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
