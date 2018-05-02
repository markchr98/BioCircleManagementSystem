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

namespace BioCircleManagementSystem.Views.Resources.UserControl
{
    /// <summary>
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : System.Windows.Controls.UserControl
    {
        public CustomerControl()
        {
            InitializeComponent();
        }

        public void Button_Click_ViewCustomer(object sender, MouseButtonEventArgs e)
        {
            ((CustomerControl)sender).CustomerName
        }

    }
}
