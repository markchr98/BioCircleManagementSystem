using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.Model
{
    class Steeltop
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
        private string _steeltopType;

        public string SteeltopType
        {
            get
            {
                return _steeltopType;
            }
            set
            {
                _steeltopType = value; OnPropertyChanged("SteeltopType");
            }
        }

        public void CreateSteeltop()
        {
            DataManager.Instance.CreateSteeltop(this);
        }
    }
}
