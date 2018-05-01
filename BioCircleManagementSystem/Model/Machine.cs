using BioCircleManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class Machine
    {
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

        public string VesselType { get { return _vesselType; } set { _vesselType = value; } }
        public string VesselNo { get { return _vesselNo; } set { _vesselNo = value; } }
        public string MachineNo { get { return _machineNo; } set { _machineNo = value; } }
        public string ControlBoxNo { get { return _controlBoxNo; } set { _controlBoxNo = value; } }
        public string InstallationDate { get { return _installationDate; } set { _installationDate = value; } }
        public string Wheels { get { return _wheels; } set { _wheels = value; } }
        public string InoxGrid { get { return _inoxGrid; } set { _inoxGrid = value; } }
        public string Lid { get { return _lid; } set { _lid = value; } }
        public string SteelTop { get { return _steelTop; } set { _steelTop = value; } }
        public string CanBringLiquid { get { return _canBringLiquid; } set { _canBringLiquid = value; } }

        public void GetMachine(string machineID)
        {
            DataManager.Instance.GetMachine(machineID);
        }

        // Public constructors
        public Machine()
        {

        }

        public Machine(string vesselNumber, string vesselType, string machineNo)
        {
            _vesselNo = vesselNumber;
            _vesselType = vesselType;
            _machineNo = machineNo;
        }
    }
}
