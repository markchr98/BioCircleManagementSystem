using BioCircleManagementSystem.ViewModels;
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

namespace BioCircleManagementSystem.Views.Orders
{
    /// <summary>
    /// Interaction logic for OrderShell.xaml
    /// </summary>
    public partial class OrderShell : Page
    {
        public OrderShell()
        {
            InitializeComponent();
            
        }

        private void Button_Click_TestFind(object sender, RoutedEventArgs e)
        {
            ChangeOtherButtonsBG(sender);
            _orderFrame.Navigate(new OrderFind());
        }

        private void Button_Click_TestCreate(object sender, RoutedEventArgs e)
        {
            ChangeOtherButtonsBG(sender);
        }

        private void Button_Click_OrderCreate(object sender, RoutedEventArgs e)
        {
            ChangeOtherButtonsBG(sender);
            _orderFrame.Navigate(new OrderCustomerCreate());
        }

        // Used to change other buttons background to default color
        private void ChangeOtherButtonsBG(object sender)
        {
            StackPanel Parent = ((StackPanel)((Button)sender).Parent);
            foreach (Button button in Parent.Children)
            {
                if (button != (Button)sender)
                {
                    button.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6C6969"));
                }
            }
        }
    }
}
