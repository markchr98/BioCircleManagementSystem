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
    /// Interaction logic for OrderCustomerCreate.xaml
    /// </summary>
    public partial class OrderCustomerCreate : Page
    {
        OrderCreateViewModel orderCreateViewModel;
        public OrderCustomerCreate()
        {
            InitializeComponent();
            orderCreateViewModel = new OrderCreateViewModel();
            DataContext = orderCreateViewModel;
        }

        //public void CheckBox1_CheckedChanged(Object sender, EventArgs e)
        //{
        //   if(CheckBox1.IsChecked == true)
        //   {
        //        CheckBox1.Content = "Ja";
        //   }
        //   else
        //   {
        //        CheckBox1.Content = "Nej";
        //   }
                       

        //}

    }
}
