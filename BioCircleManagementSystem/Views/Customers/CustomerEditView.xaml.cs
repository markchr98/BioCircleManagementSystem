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

        public void Button_Click_RemoveContact(object sender, RoutedEventArgs e)
        {
            Button contact = ((Button)sender);
            if (contact.DataContext is Contact deleteme)
            {
                customerFindViewModel.RemoveContact(deleteme);
            }
        }

        public void Test(object sender, RoutedEventArgs e)
        {
            customerFindViewModel.Test();
        }
    }
}
