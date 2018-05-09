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
        private string vesselType;
        private string vesselNo;
        private string machineNo;
        private string controlBoxNo;
        private string installationDate;
        private string wheels;
        private string inoxGrid;
        private string lid;
        private string steelTop;
        private string canBringLiquid;
        private int _serviceInterval;
        private bool _serviceContract;

        // Required when using data binding
        public event PropertyChangedEventHandler PropertyChanged;

        // Define the public accessable variables of this model
        public string VesselType {
            get
            {
                return vesselType;
            }
            set
            {
                vesselType = value;
                OnPropertyChanged("VesselType");
            }
        }
        public string VesselNo
        {
            get
            {
                return vesselNo;
            }
            set
            {
                vesselNo = value;
                OnPropertyChanged("VesselNo");
            }
        }
        public string MachineNo
        {
            get
            {
                return machineNo;
            }
            set
            {
                machineNo = value;
                OnPropertyChanged("MachineNo");
            }
        }
        public string ControlBoxNo
        {
            get
            {
                return controlBoxNo;
            }
            set
            {
                controlBoxNo = value;
                OnPropertyChanged("ControlBoxNo");
            }
        }
        public string InstallationDate
        {
            get
            {
                return installationDate;
            }
            set
            {
                installationDate = value;
                OnPropertyChanged("InstallationDate");
            }
        }
        public string Wheels
        {
            get
            {
                return wheels;
            }
            set
            {
                wheels = value;
                OnPropertyChanged("Wheels");
            }
        }
        public string InoxGrid
        {
            get
            {
                return inoxGrid;
            }
            set
            {
                inoxGrid = value;
                OnPropertyChanged("InoxGrid");
            }
        }
        public string Lid
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
                OnPropertyChanged("Lid");
            }
        }
        public string SteelTop
        {
            get
            {
                return steelTop;
            }
            set
            {
                steelTop = value;
                OnPropertyChanged("SteelTop");
            }
        }
        public string CanBringLiquid
        {
            get
            {
                return canBringLiquid;
            }
            set
            {
                canBringLiquid = value;
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
            get { return _serviceContract; }
            set { _serviceContract = value; OnPropertyChanged("ServiceContract"); }
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
