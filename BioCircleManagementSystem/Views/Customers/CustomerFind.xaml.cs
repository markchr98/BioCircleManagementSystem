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
        private static CustomerFind _instance;
        public static CustomerFind Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CustomerFind();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        private CustomerFind()
        {
            InitializeComponent();
            customerFindViewModel = CustomerFindViewModel.Instance;
            DataContext = customerFindViewModel;
        }

        // Data Binding
        // Bindes til sin egen instance af ViewModel
        private void Button_Click_SearchCustomers(object sender, RoutedEventArgs e)
        {
            customerFindViewModel.SearchCustomers(SearchBox.Text);
        }

        private void customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if statement to prevent endless loop caused by UnselectAll() causing a slectionChanged event
            if(customers.SelectedItem != null) { 
            //Might be changed to page with navigation in frame 
                CustomerEditView CEV = new CustomerEditView();            
                ShellWindow window = new ShellWindow();
                window.WindowState = WindowState.Normal;
                window.Content = CEV;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
                window.Height = 450;
                window.Width = 900;
                customers.UnselectAll(); 
                //Unselect current item so that a selection changed does not happen again
                //when exiting and re-entering the find customer page
            }
        }
    }
}
