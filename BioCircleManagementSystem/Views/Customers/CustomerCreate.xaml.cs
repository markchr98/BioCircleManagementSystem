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


namespace BioCircleManagementSystem.Views.Customers
{
    /// <summary>
    /// Interaction logic for CustomerCreate.xaml
    /// </summary>
    public partial class CustomerCreate : Page
    {
        public CustomerCreate()
        {
            InitializeComponent();
        }
        public void RemoveTextOnFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        public void Button_Click_AddContact(object sender, RoutedEventArgs e)
        {            
            contactList.Children.Add(new ContactPerson());
        }
      
        public void Button_Click_CustomerCreate(object sender, RoutedEventArgs e)
        {
            if (IsDigitsOnly(billingZipcode.Text) && IsDigitsOnly(installationZipcode.Text) && IsDigitsOnly(economicsCustomerNumber.Text))
            {
                CustomerViewModel.Instance.NewCustomer(customerName.Text, billingAddress.Text, Int32.Parse(billingZipcode.Text), billingCity.Text, installationCity.Text, Int32.Parse(installationZipcode.Text), installationCity.Text, Int32.Parse(economicsCustomerNumber.Text));
                int CustomerID = CustomerViewModel.Instance.GetLastCustomerID();
                foreach (ContactPerson CP in contactList.Children)
                {
                    CustomerViewModel.Instance.NewContact(CP.name.Text, Int32.Parse(CP.mobilePhone.Text), CP.email.Text, Int32.Parse(CP.landline.Text), CustomerID);
                }
                //Opens the notification when the button is pressed.
                //ShowDialog prohibits the user from interacting on the main window until the new window has been closed.
                CustomerCreatedNotification CCN = new CustomerCreatedNotification();
                CCN.ShowDialog();

                Clear();
            }
            else
            {
                CustomerCreatedNotification CCN = new CustomerCreatedNotification();
                CCN.Output.Text = "Venligst tjek at Zipcode og E-conomic kunde nr. kun indeholder tal";                
            }
        }

        public void Button_Click_CustomerClear(object sender, RoutedEventArgs e)
        {
            Clear();
            
        }

        private void Clear()
        {
            customerName.Text = "Virksomhedsnavn";
            billingAddress.Text = "Adresse";
            billingCity.Text = "By";
            billingZipcode.Text = "Post nr.";
            installationAddress.Text = "Adresse";
            installationCity.Text = "By";
            installationZipcode.Text = "Post nr.";

            contactList.Children.Clear();
        }

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
    }
}
