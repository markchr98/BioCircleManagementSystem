using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.Model
{
    public class Steeltop
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
        private string _type;

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value; OnPropertyChanged("Type");
            }
        }

        public void CreateSteeltop()
        {
            DataManager.Instance.CreateSteeltop(this);
        }
    }
}
