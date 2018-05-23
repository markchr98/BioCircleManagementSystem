using BioCircleManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    public class Contact : INotifyPropertyChanged
    {
        //Private fields
        private int _id;
        private string _name;
        private string _mobilePhone;
        private string _email;
        private string _landline;
        private int _customerID;
        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged("Customer"); }
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

        //Public properties
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Mobilephone
        {
            get { return _mobilePhone; }
            set
            {
                _mobilePhone = value;
                OnPropertyChanged("Mobilephone");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Landline
        {
            get { return _landline; }
            set
            {
                _landline = value;
                OnPropertyChanged("Landline");
            }
        }
        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        //Public constructor
        public Contact()
        {

         }

        public Contact(string name, string mobilePhone, string email, string landline, int customerID)
        {
            _name = name;
            _mobilePhone = mobilePhone;
            _email = email;
            _landline = landline;
            _customerID = customerID;
        }

        internal void CreateContact()
        {
            DataManager.Instance.CreateContact(this);
        }
    }
}

