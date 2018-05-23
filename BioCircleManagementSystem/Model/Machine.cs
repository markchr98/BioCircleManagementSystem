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
        private DateTime _installationDate;
        private string _wheels;
        private string _inoxGrid;
        private string _lid;
        private Steeltop _steelTop;
        private string _canBringLiquid;
        private int _serviceInterval;
        private string _serviceContract;
        private Customer _customer;
        private Filters _filters;
        private Brush _brush;
        private Liquid _liquid;
        private Status _status;
        private int _lastService;
        private int _ID;
        private Department _department;
       

        // Required when using data binding
        public event PropertyChangedEventHandler PropertyChanged;

        // Define the public accessable variables of this model
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
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
        DateTime MinValue = Convert.ToDateTime("01-01-2000");
        public DateTime InstallationDate
        {
            get
            {
                if(_installationDate < MinValue)
                {
                    return MinValue;
                }
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
        public Steeltop SteelTop
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
                OnPropertyChanged("NextService");
                OnPropertyChanged("WeekTillNextService");
            }
        }


        public string ServiceContract
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

        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                OnPropertyChanged("CustomerID");
            }
        }

        public Filters Filters
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

        public Brush Brush
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

        public Liquid Liquid
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

        public Status Status
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

        public int LastService
        {
            get
            {
                return _lastService;
            }
            set
            {
                _lastService = value;
                OnPropertyChanged("LastService");
                OnPropertyChanged("NextService");
                OnPropertyChanged("WeekTillNextService");
            }
        }
        public int NextService
        {
            get
            {
                return _lastService + _serviceInterval;
            }
        }
        public int WeekTillNextService
        {
            get
            {
                return NextService - ((DateTime.Now.DayOfYear / 7) + 1);
            }
        }

        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                OnPropertyChanged("Department");
            }
        }

        // Public constructors
        public Machine()
        {
            SteelTop = new Steeltop();
            Status = new Status();
            Liquid = new Liquid();
            Brush = new Brush();
            Filters = new Filters();
            Customer = new Customer();
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
