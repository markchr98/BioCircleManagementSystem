using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BioCircleManagementSystem.Views.Resources.UserControl;
using BioCircleManagementSystem.Views.Resources.Notifications;
using BioCircleManagementSystem.ViewModels;
using BioCircleManagementSystem.Model;

namespace BioCircleManagementSystem.Views.Customers
{
    /// <summary>
    /// Interaction logic for CustomerCreate.xaml
    /// </summary>
    public partial class CustomerCreate : Page
    {
        CustomerCreateViewModel customerCreateViewModel;
        public CustomerCreate()
        {
            InitializeComponent();
            customerCreateViewModel = new CustomerCreateViewModel();
            DataContext = customerCreateViewModel;
        }
        public void RemoveTextOnFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        public void Button_Click_AddContact(object sender, RoutedEventArgs e)
        {
            customerCreateViewModel.AddContact();
            //contactlist er en stack panel
            // new ContactPerson er UserControl
            //contactList.Children.Add(new ContactPerson());
        }       

        public void Button_Click_RemoveContact(object sender, RoutedEventArgs e)
        {
            Button contact = ((Button)sender);
            if (contact.DataContext is Contact deleteme)
            {
                customerCreateViewModel.RemoveContact(deleteme);
            }
        }

        public void Button_Click_AddDepartment(object sender, RoutedEventArgs e)
        {
            customerCreateViewModel.AddDepartment();
        }

        public void Button_Click_RemoveDepartment(object sender, RoutedEventArgs e)
        {
            Button Department = ((Button)sender);
            if (Department.DataContext is Department deleteme)
            {
                customerCreateViewModel.RemoveDepartment(deleteme);
            }
        }

        public void Button_Click_CustomerCreate(object sender, RoutedEventArgs e)
        {
            customerCreateViewModel.CreateCustomer();
            //// Skal som minimum ned i ViewModel 
            //bool isDigitsOnly = false;
            //if (IsDigitsOnly(billingZipcode.Text) && IsDigitsOnly(installationZipcode.Text) && IsDigitsOnly(economicsCustomerNumber.Text))
            //{
               
            //    foreach (ContactPerson CP in contactList.Children)
            //    {
            //        if (IsDigitsOnly(CP.mobilePhone.Text) && IsDigitsOnly(CP.landline.Text))
            //        {
            //            isDigitsOnly = true;
            //        }
            //        else
            //        {
            //            isDigitsOnly = false;
            //            break;
            //        }
                    
            //    }
            //    if (isDigitsOnly)
            //    {
            //        CustomerViewModel.Instance.NewCustomer(customerName.Text, billingAddress.Text, Int32.Parse(billingZipcode.Text), billingCity.Text, installationCity.Text, Int32.Parse(installationZipcode.Text), installationCity.Text, Int32.Parse(economicsCustomerNumber.Text));
            //        int CustomerID = CustomerViewModel.Instance.GetNewestCustomerID();
            //        foreach (ContactPerson CP in contactList.Children)
            //        {
            //            CustomerViewModel.Instance.NewContact(CP.name.Text, Int32.Parse(CP.mobilePhone.Text), CP.email.Text, Int32.Parse(CP.landline.Text), CustomerID);
            //        }
            //        Notification CCN1 = new Notification();
            //        CCN1.Output.Text = "Ny kunde oprettet";
            //        CCN1.ShowDialog();

            //        Clear();
            //    }
            //    else
            //    {
            //        Notification CCN2 = new Notification();
            //        CCN2.Output.Text = "Venligst tjek at mobil og fastnet \nkun indeholder tal";
            //        CCN2.ShowDialog();
            //    }              
            //}
            //else
            //{
            //    Notification CCN3 = new Notification();
            //    CCN3.Output.Text = "Venligst tjek at Zipcode og \nE-conomic kunde nr. kun indeholder tal";
            //    CCN3.ShowDialog();
            //}
        }

        public void Button_Click_CustomerClear(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            customerCreateViewModel.ClearCustomer();
        }

        // minimum Viewmodel Lag
        //used to ensure we can parse to int
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void customerName_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
