using BioCircleManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    public class Machine : INotifyPropertyChanged
    {
       
        // Define the private variables of this model
        private string _vesselType;
        private string _vesselNo;
        private string _machineNo;
        private string _controlBoxNo;
        private string _installationDate;
        private string _wheels;
        private string _inoxGrid;
        private string _lid;
        private string _steelTop;
        private string _canBringLiquid;
        private int _serviceInterval;
        private bool _serviceContract;
        private int _customerID;
        private string _filters;
        private string _brush;
        private string _liquid;
        private string _status;

        // Required when using data binding
        public event PropertyChangedEventHandler PropertyChanged;

        // Define the public accessable variables of this model
        public string VesselType {
            get
            {
                return _vesselType;
            }
            set
            {
                _vesselType = value;
                OnPropertyChanged("VesselType");
            }
        }
        public string VesselNo
        {
            get
            {
                return _vesselNo;
            }
            set
            {
                _vesselNo = value;
                OnPropertyChanged("VesselNo");
            }
        }
        public string MachineNo
        {
            get
            {
                return _machineNo;
            }
            set
            {
                _machineNo = value;
                OnPropertyChanged("MachineNo");
            }
        }
        public string ControlBoxNo
        {
            get
            {
                return _controlBoxNo;
            }
            set
            {
                _controlBoxNo = value;
                OnPropertyChanged("ControlBoxNo");
            }
        }
        public string InstallationDate
        {
            get
            {
                return _installationDate;
            }
            set
            {
                _installationDate = value;
                OnPropertyChanged("InstallationDate");
            }
        }

        public string Wheels
        {
            get
            {
                return _wheels;
            }
            set
            {
                _wheels = value;
                OnPropertyChanged("Wheels");
            }
        }
        public string InoxGrid
        {
            get
            {
                return _inoxGrid;
            }
            set
            {
                _inoxGrid = value;
                OnPropertyChanged("InoxGrid");
            }
        }
        public string Lid
        {
            get
            {
                return _lid;
            }
            set
            {
                _lid = value;
                OnPropertyChanged("Lid");
            }
        }
        public string SteelTop
        {
            get
            {
                return _steelTop;
            }
            set
            {
                _steelTop = value;
                OnPropertyChanged("SteelTop");
            }
        }
        public string CanBringLiquid
        {
            get
            {
                return _canBringLiquid;
            }
            set
            {
                _canBringLiquid = value;
                OnPropertyChanged("CanBringLiquid");
            }
        }
        public int ServiceInterval
        {
            get
            {
                return _serviceInterval;
            }
            set
            {
                _serviceInterval = value;
                OnPropertyChanged("ServiceInterval");
            }
        }


        public bool ServiceContract
        {
            get
            {
                return _serviceContract;
            }
            set
            {
                _serviceContract = value; OnPropertyChanged("ServiceContract");
            }
        }

        public int CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        public string Filters
        {
            get
            {
                return _filters;
            }
            set
            {
                _filters = value;
                OnPropertyChanged("Filters");
            }
        }

        public string Brush
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
                OnPropertyChanged("Brush");
            }
        }

        public string Liquid
        {
            get
            {
                return _liquid;
            }
            set
            {
                _liquid = value;
                OnPropertyChanged("Liquid");
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        // Public constructors
        public Machine()
        {

        }
        public Machine(string vesselType, string vesselNo, string machineNo, string controlBoxNo)
        {
            VesselType = vesselType;
            VesselNo = vesselNo;
            MachineNo = machineNo;
        }

        public void CreateMachine()
        {
            DataManager.Instance.CreateMachine(this);
        }

        internal void UpdateMachine()
        {
            DataManager.Instance.UpdateMachine(this);
        }

        #region INotifyPropertyChanged Members
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
