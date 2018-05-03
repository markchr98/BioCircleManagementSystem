using BioCircleManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BioCircleManagementSystem.Commands.Storage
{
    internal class CreateMachineCommand : ICommand
    {
        private StorageViewModel viewModel;

        // Initializes a new instance of the "CreateMachineCommand.cs" class
        public CreateMachineCommand(StorageViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(viewModel.Machine.Error);
        }

        public void Execute(object parameter)
        {
            // Is there an easier method to access the parametes???
            viewModel.CreateMachine(viewModel.Machine.VesselNo, viewModel.Machine.VesselType, viewModel.Machine.MachineNo);
        }
        #endregion
    }
}
