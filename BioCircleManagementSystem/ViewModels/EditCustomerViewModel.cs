using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;
using BioCircleManagementSystem.DataAccess;
using System.ComponentModel;

namespace BioCircleManagementSystem.ViewModels
{
    public class EditCustomerViewModel : INotifyPropertyChanged
    {
        public Customer Customer
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private EditCustomerViewModel()
        {
            
        }

        public void DeleteCustomer()
        {
            Customer.DeleteCustomer();
        }
    }
}
