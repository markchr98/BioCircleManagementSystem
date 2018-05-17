﻿using BioCircleManagementSystem.DataAccess;
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
    class ServiceFindViewModel : INotifyPropertyChanged
    {
        private  Service _selectedService;
        public Service SelectedService
        {
            get { return _selectedService; }
            set { _selectedService = value; OnPropertyChanged("SelectedService"); }
        }

        private ObservableCollection<Service> _services;

        public ObservableCollection<Service> Services
        {
            get { return _services; }
            set { _services = value; OnPropertyChanged("Services"); }
        }

        //INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Singleton pattern with "lazy loading"
        private static ServiceFindViewModel _instance;        
        public static ServiceFindViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceFindViewModel();
                }
                return _instance;
            }
        }

        private ServiceFindViewModel()
        {
            List<Service> service = DataManager.Instance.GetServices("");
            _services = new ObservableCollection<Service>(service);
        }

        public void UpdateService()
        {
            _selectedService.Update();
        }
        
        public void GetServices(string keyword)
        {
            Services = new ObservableCollection<Service>(DataManager.Instance.GetServices(keyword));
        }
    }
}
