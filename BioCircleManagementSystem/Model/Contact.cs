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
        private string _name;
        private int _mobilePhone;
        private string _email;
        private int _landline;
        private int _customerID;

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
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Mobilephone
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
        public int Landline
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

        public Contact(string name, int mobilePhone, string email, int landline, int customerID)
        {
            _name = name;
            _mobilePhone = mobilePhone;
            _email = email;
            _landline = landline;
            _customerID = customerID;
        }

        internal void CreateContact()
        {
            int customerID = DataManager.Instance.GetNewestCustomerID();
            CustomerID = customerID;
            DataManager.Instance.CreateContact(this);
        }
    }
}

