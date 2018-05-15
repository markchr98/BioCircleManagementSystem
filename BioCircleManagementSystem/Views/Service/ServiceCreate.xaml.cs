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
    /// Interaction logic for ServiceCreate.xaml
    /// </summary>
    public partial class ServiceCreate : Page
    {
        //Singleton pattern with "lazy loading". used because of issues with instanciating pages causing dublication of events
        private static ServiceCreate _instance;
        public static ServiceCreate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceCreate();
                }
                return _instance;
            }
        }
        public ServiceCreate()
        {
            InitializeComponent();
        }

       
    }
}
