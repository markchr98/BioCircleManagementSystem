using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class Customer
    {
         //Private fields
        private string _customerName;
        private int _customerID;
        private string _billingAddress;
        private string _billingZipcode;
        private string _billingCity;
        private string _installationAddress;
        private string _installationZipcode;
        private string _installationCity;
        private List<Contact> Contacts;

        //Public properties
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        public string BillingAddress
        {
            get { return _billingAddress; }
            set { _billingAddress = value; }
        }
        public string BillingZipcode
        {
            get { return _billingZipcode; }
            set { _billingZipcode = value; }
        }
        public string BillingCity
        {
            get { return _billingCity; }
            set { _billingCity = value; }
        }
        public string InstallationAddress
        {
            get { return _installationAddress; }
            set { _installationAddress = value; }
        }
        public string InstallationZipcode
        {
            get { return _installationZipcode; }
            set { _installationZipcode = value; }
        }
        public string InstallationCity
        {
            get { return _installationCity; }
            set { _installationCity = value; }
        }

        //Public constructor
        public Customer(string customerName, int customerID, string billingAddress, string billingZipcode, string billingCity, string installationAddress, string installationZipcode, string installationCity)
        {
            _customerName = customerName;
            _customerID = customerID;
            _billingAddress = billingAddress;
            _billingZipcode = billingZipcode;
            _billingCity = billingCity;
            _installationAddress = installationAddress;
            _installationZipcode = installationZipcode;
            _installationCity = installationCity;
        }
    }
}
