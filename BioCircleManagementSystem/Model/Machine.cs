using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class Machine
    {
        public void GetMachine(string machineID)
        {
            DataManager.Instance.GetMachine(machineID);
        }
    }
}
