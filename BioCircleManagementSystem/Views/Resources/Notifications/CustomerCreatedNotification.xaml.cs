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

namespace BioCircleManagementSystem.Views.Resources.Notifications
{
    /// <summary>
    /// Interaction logic for CustomerCreatedNotification.xaml
    /// </summary>
    public partial class CustomerCreatedNotification : Window
    {
        public CustomerCreatedNotification()
        {
            InitializeComponent();
        }

        //Closes the window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
