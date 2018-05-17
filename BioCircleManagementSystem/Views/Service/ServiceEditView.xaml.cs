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

namespace BioCircleManagementSystem.Views.Service
{
    /// <summary>
    /// Interaction logic for ServiceEditView.xaml
    /// </summary>
    public partial class ServiceEditView : Page
    {
        ServiceFindViewModel serviceFindViewModel;
        public ServiceEditView()
        {
            InitializeComponent();
            serviceFindViewModel = ServiceFindViewModel.Instance;
            DataContext = serviceFindViewModel;
            DatePicker.Text = "Vælg Dato";
        }

        private void Button_Click_UpdateService(object sender, RoutedEventArgs e)
        {

        }
    }
}
