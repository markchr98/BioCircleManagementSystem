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
    /// Interaction logic for ServiceFind.xaml
    /// </summary>
    public partial class ServiceFind : Page
    {
        //Singleton pattern with "lazy loading". used because of issues with instanciating pages causing dublication of events
        private static ServiceFind _instance;
        public static ServiceFind Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceFind();
                }
                return _instance;
            }
        }

        private ServiceFind()
        {
            InitializeComponent();
        }

        
    }
}
