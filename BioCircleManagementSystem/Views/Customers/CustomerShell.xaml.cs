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

namespace BioCircleManagementSystem.Views.Customers
{
    /// <summary>
    /// Interaction logic for CustomerCreate.xaml
    /// </summary>
    public partial class CustomerShell : Page
    {
        public CustomerShell()
        {
            InitializeComponent();
        }

        private void Button_Click_CustomerFind(object sender, RoutedEventArgs e)
        {
            _customerFrame.Navigate(new CustomerFind());
        }

        private void Button_Click_CustomerCreate(object sender, RoutedEventArgs e)
        {
            _customerFrame.Navigate(new CustomerCreate());
        }
    }
}
