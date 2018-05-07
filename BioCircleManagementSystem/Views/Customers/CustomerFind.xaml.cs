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
        CustomerFindViewModel customerFindViewModel;
        public CustomerFind()
        {
            InitializeComponent();
            customerFindViewModel = new CustomerFindViewModel();
            DataContext = customerFindViewModel;
        }

        // Data Binding
        // Bindes til sin egen instance af ViewModel
        private void Button_Click_SearchCustomers(object sender, RoutedEventArgs e)
        {
            customerFindViewModel.SearchCustomers(SearchBox.Text);
        }
    }
}
