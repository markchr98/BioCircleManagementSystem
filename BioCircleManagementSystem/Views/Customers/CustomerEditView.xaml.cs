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
using BioCircleManagementSystem.Model;
using BioCircleManagementSystem.ViewModels;

namespace BioCircleManagementSystem.Views.Customers
{
    /// <summary>
    /// Interaction logic for CustomerEditView.xaml
    /// </summary>
    public partial class CustomerEditView : Page
    {
        CustomerFindViewModel customerFindViewModel;
        
        public CustomerEditView()
        {
            InitializeComponent();
            customerFindViewModel = CustomerFindViewModel.Instance;
            DataContext = customerFindViewModel;
        }
        public void Button_Click_RemoveDepartment(object sender, RoutedEventArgs e)
        {
            Resources.Notifications.Confirmations confirmation = new Resources.Notifications.Confirmations();
            confirmation.Output.Text = "Vil du slette denne afdeling?";
            confirmation.ShowDialog();
            if (confirmation.confirmed)
            {
                Button department = ((Button)sender);
                if (department.DataContext is Department deleteme)
                {
                    customerFindViewModel.DeleteDepartment(deleteme);
                }
            }
        }
        public void Button_Click_RemoveContact(object sender, RoutedEventArgs e)
        {
            Resources.Notifications.Confirmations confirmation = new Resources.Notifications.Confirmations();
            confirmation.Output.Text = "Vil du slette denne kontaktperson?";
            confirmation.ShowDialog();
            if (confirmation.confirmed)
            {
                Button contact = ((Button)sender);
                if (contact.DataContext is Contact deleteme)
                {
                    customerFindViewModel.RemoveContact(deleteme);
                }
            }
        }

        public void Test(object sender, RoutedEventArgs e)
        {
            customerFindViewModel.Test();
        }

        private void contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_UpdateCustomer(object sender, RoutedEventArgs e)
        {
            Resources.Notifications.Confirmations confirmation = new Resources.Notifications.Confirmations();
            confirmation.Output.Text = "Vil du gemme ændringerne?";
            confirmation.ShowDialog();
            if (confirmation.confirmed)
            {
                customerFindViewModel.UpdateCustomer();
                ((Window)this.Parent).Close();
            }
        }

        private void Button_Click_DeleteCustomer(object sender, RoutedEventArgs e)
        {
            Resources.Notifications.Confirmations confirmation = new Resources.Notifications.Confirmations();
            confirmation.Output.Text = "Vil du slette denne kunde?";
            confirmation.ShowDialog();
            if (confirmation.confirmed)
            {
                customerFindViewModel.DeleteCustomer();
                ((Window)this.Parent).Close();
            }
        }

        private void contacts_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
