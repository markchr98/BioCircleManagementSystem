﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.DataAccess;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.ViewModels
{
    public class CustomerCreateViewModel:INotifyPropertyChanged
    {
        public Customer Customer { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }        
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Constructor 
        public CustomerCreateViewModel()
        {            
            Customer = new Customer();
            Contacts = new ObservableCollection<Contact>();
        }       
        

        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        public void AddContact()
        {
            Contacts.Add(new Contact());
        }

        public void CreateCustomer()
        {
            //how da fuk we deal wit contacts
            Customer.CreateCustomer();
        }

        public List<Customer> GetCustomers(string keyword)
        {
            return DataManager.Instance.GetCustomers(keyword);
        }

        public void ClearCustomer()
        {
            Customer.CustomerName = "";
            Customer.EconomicsCustomerNumber = "";
            Customer.BillingAddress = "";
            Customer.BillingCity = "";
            Customer.BillingZipcode = "";
            Customer.InstallationAddress = "";
            Customer.InstallationCity = "";
            Customer.InstallationZipcode = "";
            Contacts.Clear();
            
        }
    }
}
