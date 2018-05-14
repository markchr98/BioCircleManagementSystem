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
        private CustomerFind CF;
        public CustomerShell()
        {
            InitializeComponent();
            CF = CustomerFind.Instance;
        }

        private void Button_Click_CustomerFind(object sender, RoutedEventArgs e)
        {
            ChangeOtherButtonsBG(sender);
            _customerFrame.Navigate(CF);
        }

        private void Button_Click_CustomerCreate(object sender, RoutedEventArgs e)
        {
            ChangeOtherButtonsBG(sender);
            _customerFrame.Navigate(new CustomerCreate());
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
