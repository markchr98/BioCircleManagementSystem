using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    internal class StorageFindViewModel : INotifyPropertyChanged
    {
        public Machine _selectedMachine;

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
