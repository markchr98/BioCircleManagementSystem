using BioCircleManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using System.Windows.Input;
using BioCircleManagementSystem.Commands.Storage;

namespace BioCircleManagementSystem.ViewModels
{
    internal class StorageViewModel
    {
        public Machine machine { get; set; }
        //Constructor
        public StorageViewModel()
        {
            machine = new Machine();
            CreateCommand = new CreateMachineCommand(this);
        }

        // Gets the costumer instance (this is public accessable)
        public Machine Machine
        {
            get
            {
                return machine;
            }
        }

        public ICommand CreateCommand
        {
            get;
            private set;
        }

        public void CreateMachine(string vesselNo, string vesselType, string machineNo)
        {
            DataAccess.DataManager.Instance.CreateMachine(new Machine(vesselNo, vesselType, machineNo));
        }
    }
}
