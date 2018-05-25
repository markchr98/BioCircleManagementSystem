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
using BioCircleManagementSystem.ViewModels;

namespace BioCircleManagementSystem.Views.Resources.Notifications
{
    /// <summary>
    /// Interaction logic for Confirmations.xaml
    /// </summary>
    public delegate void Confirmation();
    public partial class Confirmations : Window
    {
        public bool confirmed;
        public Confirmations()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_OptionTwo(object sender, RoutedEventArgs e)
        {
            this.Close();
            confirmed = false;
        }

        private void Button_Click_OptionOne(object sender, RoutedEventArgs e)
        {
            confirmed = true;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
