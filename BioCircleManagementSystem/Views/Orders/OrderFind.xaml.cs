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
using BioCircleManagementSystem.ViewModels;

namespace BioCircleManagementSystem.Views.Orders
{
    /// <summary>
    /// Interaction logic for OrderFind.xaml
    /// </summary>
    public partial class OrderFind : Page
    {
        OrderFindViewModel orderFindViewModel;
        
        public OrderFind()
        {
            InitializeComponent();
            orderFindViewModel = OrderFindViewModel.Instance;
        }

        private void Button_Click_SearchOrders(object sender, RoutedEventArgs e)
        {
            orderFindViewModel.SearchOrders(SearchBox.Text);
        }

        private void machines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if statement to prevent endless loop caused by UnselectAll() causing a slectionChanged event
            if (machines.SelectedItem != null)
            {
                //Might be changed to page with navigation in frame 
                OrderCreateViewModel CEV = new OrderCreateViewModel();
                ShellWindow window = new ShellWindow();
                window.WindowState = WindowState.Normal;
                window.Content = CEV;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
                window.Height = 450;
                window.Width = 900;
                machines.UnselectAll();
                //Unselect current item so that a selection changed does not happen again
                //when exiting and re-entering the find customer page
            }
        }
    }
}
