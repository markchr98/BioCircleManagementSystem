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
    /// Interaction logic for ServiceShell.xaml
    /// </summary>
    public partial class ServiceShell : Page
    {
        private ServiceFind SF;
        private ServiceCreate SC;
        private static ServiceShell _instance;
        public ServiceShell()
        {
            InitializeComponent();
           


        }
        public static ServiceShell Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceShell();
                }
                return _instance;
            }
        }

        public void Button_Click_ServiceFind(object sender, RoutedEventArgs e)
        {
            SF = ServiceFind.Instance;
            _serviceFrame.Navigate(SF);
        }

        public void Button_Click_ServiceCreate(object sender, RoutedEventArgs e)
        {
            SC = ServiceCreate.Instance;
            _serviceFrame.Navigate(SC);
        }
    }
}
