using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.Model
{
    public class Brush : INotifyPropertyChanged
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

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged("ID"); }
        }

        public void CreateBrush()
        {
            DataManager.Instance.CreateBrush(this);
        }
    }
}
