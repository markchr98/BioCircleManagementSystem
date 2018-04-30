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

        private void Button_Click_SearchForCustomer(object sender, RoutedEventArgs e)
        {
            
        }

        public void RemoveFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text.Count();
            if(SearchBox.Text.Count() > 3)
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
