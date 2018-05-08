using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private double _tempature;
        private string _cleaningEffect;

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

    }
}
