using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    public class Status : INotifyPropertyChanged
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
        public Status()
        {

        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        private string _currentStatus;

        public string CurrentStatus { get { return _currentStatus; } set { _currentStatus = value; OnPropertyChanged("CurrentStatus"); } }

        
    }
}
