using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class Contact
    {
        //private fields
        private string _name;
        private string _mobilePhone;
        private string _email;
        private string _landline;
        private string _customerID;
       
        //public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Mobilephone
        {
            get { return _mobilePhone; }
            set { _mobilePhone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Landline
        {
            get { return _landline; }
            set { _landline = value; }
        }
        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        //public constructor
        public Contact(string name, string mobilePhone, string email, string landline, string customerID)
        {
            _name = name;
            _mobilePhone = mobilePhone;
            _email = email;
            _landline = landline;
            _customerID = customerID;
        }

    }
}
