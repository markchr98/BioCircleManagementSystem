using BioCircleManagementSystem.Views.Customers;
using BioCircleManagementSystem.Views.Orders;
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
using System.Windows.Shapes;

namespace BioCircleManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CustomersButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CustomerShell());
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OrderShell());
        }
    }
}
