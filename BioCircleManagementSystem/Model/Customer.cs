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
        private int _billingZipcode;
        private string _billingCity;
        private string _installationAddress;
        private int _installationZipcode;
        private string _installationCity;
        private List<Contact> _contacts;
        private int _economicsCustomerNumber;

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
        public int BillingZipcode
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
        public int InstallationZipcode
        {
            get { return _installationZipcode; }
            set { _installationZipcode = value; }
        }
        public string InstallationCity
        {
            get { return _installationCity; }
            set { _installationCity = value; }
        }

        public List<Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }

        public int EconomicsCustomerNumber
        {
            get { return _economicsCustomerNumber; }
            set { _economicsCustomerNumber = value; }
        }

        //Public constructors
        public Customer()
        {

        }
        public Customer(string customerName, string billingAddress, int billingZipcode, string billingCity, string installationAddress, int installationZipcode, string installationCity, int economicsCustomerNumber)
        {
            _customerName = customerName;
            _billingAddress = billingAddress;
            _billingZipcode = billingZipcode;
            _billingCity = billingCity;
            _installationAddress = installationAddress;
            _installationZipcode = installationZipcode;
            _installationCity = installationCity;
            _economicsCustomerNumber = economicsCustomerNumber;
        }
    }
}
