using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    public class Filters : INotifyPropertyChanged
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
        private string _type;
        private string _house;
        private string _typeHouse;

        public int ID { get { return _ID; } set{ _ID = value; OnPropertyChanged("ID"); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }
        public string House { get { return _house; } set { _house = value; OnPropertyChanged("House"); } }
        public string TypeHouse { get { return _typeHouse; } set { _typeHouse = value; OnPropertyChanged("TypeHouse"); } }
    }
}
