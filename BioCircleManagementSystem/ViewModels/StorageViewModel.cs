using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.ViewModels
{
    class StorageViewModel
    {
        private static StorageViewModel instance;
        //Constructor
        private StorageViewModel()
        {

        }
        public static StorageViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StorageViewModel();
                }
                return instance;
            }
        }

        public void NewMachine(int machineNumber, string machineType)
        {
            //DataManager.Instance.CreateCustomer(new Customer(customerName, billingAddress, billingZipcode, billingCity, installationAddress, installationZipcode, installationCity, economicsCustomerNumber));

        }
    }
}
