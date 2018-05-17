using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;


namespace BioCircleManagementSystem.Model
{
    class Service : INotifyPropertyChanged
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
        private int _ID;
        private int _weekNumber;
        private int _nextWeekNumber;
        private int _arrival;
        private int _depature;
        private int _PHValue;
        private string _smell;
        private double _temperature;
        private string _cleaningEffect;
        private Machine _machine;
        private Technician _technician;

        public Technician Technician
        {
            get { return _technician; }
            set { _technician = value; OnPropertyChanged("Technician"); }
        }


        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged("ID"); }
        }

        public int WeekNumber
        {
            get { return _weekNumber; }
            set { _weekNumber = value; OnPropertyChanged("WeekNumber"); }
        }
        public int NextWeekNumber
        {
            get { return _nextWeekNumber; }
            set { _nextWeekNumber = value; OnPropertyChanged("NextWeekNumber"); }
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public int Arrival
        {
            get { return _arrival; }
            set { _arrival = value; OnPropertyChanged("Arrival"); }
        }

        public int Depature
        {
            get { return _depature; }
            set { _depature = value; OnPropertyChanged("Depature"); }
        }
        public int PHValue
        {
            get { return _PHValue; }
            set { _PHValue = value; OnPropertyChanged("PHValue"); }
        }
        public string Smell
        {
            get { return _smell; }
            set { _smell = value; OnPropertyChanged("Smell"); }
        }
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; OnPropertyChanged("Temperature"); }
        }
        public string CleaningEffect
        {
            get { return _cleaningEffect; }
            set { _cleaningEffect = value; OnPropertyChanged("CleaningEffect"); }
        }

        public Machine Machine
        {
            get { return _machine; }
            set { _machine = value; OnPropertyChanged("Machine"); }
        }

        public Service()
        {

        }

        public void CreateService()
        {
            _machine.LastService = ((DateTime.Now.DayOfYear / 7) + 1);
            DataManager.Instance.CreateService(this);
        }
    }
}
