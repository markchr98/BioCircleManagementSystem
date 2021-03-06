﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.Model;
using BioCircleManagementSystem.DataAccess;
using System.ComponentModel;

namespace BioCircleManagementSystem.ViewModels
{
    class CustomerFindViewModel : INotifyPropertyChanged
    {
        private Customer _selectedCustomer;
        
             
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        private static CustomerFindViewModel _instance;

        public static CustomerFindViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerFindViewModel();
                }
                return _instance;
            }
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {   
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }

        private CustomerFindViewModel()
        {
            List<Customer> customers = DataManager.Instance.GetCustomers("");
            _customers = new ObservableCollection<Customer>(customers);
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
        

        public void RemoveContact(Contact deleteme)
        {
            SelectedCustomer.RemoveContact(deleteme);
        }

        public void SearchCustomers(string keyword)
        {
            Customers = new ObservableCollection<Customer>(DataManager.Instance.GetCustomers(keyword));
        }

        public void AddContact()
        {
            SelectedCustomer.AddContact(new Contact());
        }

        public void UpdateCustomer()
        {
            _selectedCustomer.UpdateCustomer();
        }
        public void DeleteCustomer()
        {
            SelectedCustomer.DeleteCustomer();
        }
        public void DeleteDepartment(Department department)
        {
            SelectedCustomer.DeleteDepartment(department);
        }
    }
}
