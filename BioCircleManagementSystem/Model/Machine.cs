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

        public string VesselType { get { return vesselType; } set { vesselType = value; } }
        public string VesselNo { get { return vesselNo; } set { vesselNo = value; } }
        public string MachineNo { get { return machineNo; } set { machineNo = value; } }
        public string ControlBoxNo { get { return controlBoxNo; } set { controlBoxNo = value; } }
        public string InstallationDate { get { return installationDate; } set { installationDate = value; } }
        public string Wheels { get { return wheels; } set { wheels = value; } }
        public string InoxGrid { get { return inoxGrid; } set { inoxGrid = value; } }
        public string Lid { get { return lid; } set { lid = value; } }
        public string SteelTop { get { return steelTop; } set { steelTop = value; } }
        public string CanBringLiquid { get { return canBringLiquid; } set { canBringLiquid = value; } }

        public void GetMachine(string machineID)
        {
            DataManager.Instance.GetMachine(machineID);
        }
    }
}
