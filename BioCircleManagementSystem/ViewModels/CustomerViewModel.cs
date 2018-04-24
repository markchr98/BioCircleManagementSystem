using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    class CustomerViewModel
    {
        //Public constructor
        public CustomerViewModel()
        {

        }
        
        public void NewCustomer(string customerName, int customerID, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity)
        {
            DataManager.Instance.CreateCustomer(new Customer(customerName,customerID,billingAddress,billingZipcode,billingCity,installationAddress,installationZipcode,installationCity));
        }
    }
}
