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
            CustomerViewModel.Instance.NewCustomer(customerName.ToString(), billingAddress.ToString(), billingCity.ToString(), billingZipcode.ToString(), installationCity.ToString(), installationCity.ToString(), installationZipcode.ToString());
        }

        public void Button_Click_CustomerClear(object sender, RoutedEventArgs e)
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
    }
}
