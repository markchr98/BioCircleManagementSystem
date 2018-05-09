using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;

namespace BioCircleManagementSystem.Model
{
    public class Department
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion Property
        private string _installationAddress;
        private string _installationZipcode;
        private string _installationCity;
        private string _canBringLiquid;
        private string _customerID;

        public string InstallationAddress
        {
            get
            {
                return _installationAddress;
            }
            set
            {
                _installationAddress = value; OnPropertyChanged("InstallationAddress");
            }
        }
        public string InstallationCity
        {
            get
            {
                return _installationCity;
            }
            set
            {
                _installationCity = value; OnPropertyChanged("InstallationCity");
            }
        }
        public string InstallationZipcode
        {
            get
            {
                return _installationZipcode;
            }
            set
            {
                _installationZipcode = value; OnPropertyChanged("InstallationZipcode");
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
                _canBringLiquid = value; OnPropertyChanged("CanBringLiquid");
            }
        }
        public string CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value; OnPropertyChanged("CustomerID");
            }
        }
        public Department()
        {

        }
        public Department(string installationAddress, string installationsCity, string installationZipcode, string canBringLiquid)
        {

        }
        public void CreateDepartment()
        {
            DataManager.Instance.CreateDepartment(this);
        }
    }
}
