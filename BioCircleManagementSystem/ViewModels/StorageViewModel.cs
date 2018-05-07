using BioCircleManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using System.Windows.Input;

namespace BioCircleManagementSystem.ViewModels
{
    internal class StorageViewModel
    {
        public Machine machine { get; set; }
        //Constructor
        public StorageViewModel()
        {
            machine = new Machine();
        }

        // Gets the machine instance (this is public accessable)
        public Machine Machine
        {
            get
            {
                return machine;
            }
        }

        public void CreateMachine()
        {
            Machine.CreateMachine();
        }

        public void ClearMachine()
        {
            Machine.VesselType = "";
            Machine.VesselNo = "";
            Machine.MachineNo = "";
            Machine.ControlBoxNo = "";
            Machine.InstallationDate = "";
            Machine.Wheels = "";
            Machine.InoxGrid = "";
            Machine.Lid = "";
            Machine.SteelTop = "";
            Machine.CanBringLiquid = "";
        }
    }
}
