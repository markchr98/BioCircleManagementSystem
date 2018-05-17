using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    public class Technician : INotifyPropertyChanged
    {
        #region Property
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
        private int _ID;
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private int _mobilrPhone;
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }


        public int MobilePhone
        {
            get { return _mobilrPhone; }
            set { _mobilrPhone = value; OnPropertyChanged("MobilePhone"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); OnPropertyChanged("FullName"); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); OnPropertyChanged("FullName"); }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged("FirstName"); OnPropertyChanged("LastName"); OnPropertyChanged("FullName"); }
        }


        public int ID
        {
            get { return _ID; }
            set { _ID = value;}
        }

        public void CreateTechnician()
        {

        }

        public void GetTechnician()
        {

        }

        public void GetTechnicians()
        {

        }

        public void UpdateTechnician()
        {

        }

        public void DeleteTechnician()
        {

        }
    }
}
