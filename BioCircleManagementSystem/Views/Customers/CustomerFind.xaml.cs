using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using BioCircleManagementSystem.ViewModels;
using BioCircleManagementSystem.Model;
using BioCircleManagementSystem.Views.Resources.UserControl;

namespace BioCircleManagementSystem.Views.Customers
{
    /// <summary>
    /// Interaction logic for CustomerFind.xaml
    /// </summary>
    public partial class CustomerFind : Page
    {
        public CustomerFind()
        {
            InitializeComponent();
        }

        // Data Binding
        // Bindes til sin egen instance af ViewModel
        private void Button_Click_GetCustomers(object sender, RoutedEventArgs e)
        {
            CustomerList.Children.Clear();
            foreach(Customer customer in CustomerViewModel.Instance.GetCustomers(SearchBox.Text))
            {
                CustomerControl CC = new CustomerControl();
                CC.CustomerName.Text = customer.CustomerName;
                CC.EconomicsCustomerNo.Text = customer.EconomicsCustomerNumber.ToString();
                CC.InstallationAddress.Text = customer.InstallationAddress;
                CC.InstallationCity.Text = customer.InstallationCity;
                CC.InstallationZipcode.Text = customer.InstallationZipcode.ToString();
                CustomerList.Children.Add(CC);
            }
        }

        public void RemoveFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text.Count();
            if(SearchBox.Triggers.Count > 1)
            {
                SearchBox.Text = SearchBox.Text;
            }
            else
            {
                ((TextBox)sender).Text = "";
            }
        }
    }
}
