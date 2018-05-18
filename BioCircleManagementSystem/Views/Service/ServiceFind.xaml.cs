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
        ServiceFindViewModel ServiceFindViewModel;
        private ServiceFind()
        {
            InitializeComponent();
            ServiceFindViewModel = ServiceFindViewModel.Instance;
            DataContext = ServiceFindViewModel;
               
        }

       
        private void Button_Click_SearchServices(object sender, RoutedEventArgs e)
        {
            ServiceFindViewModel.Instance.GetServices(SearchBox.Text);
        }

        private void Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if statement to prevent endless loop caused by UnselectAll() causing a slectionChanged event
            if (services.SelectedItem != null)
            {
                //Might be changed to page with navigation in frame 
                ServiceEditView SEV = new ServiceEditView();
                ShellWindow window = new ShellWindow();
                window.WindowState = WindowState.Normal;
                window.Content = SEV;
                window.ShowDialog();
                window.Height = 450;
                window.Width = 900;
                services.UnselectAll();
                //Unselect current item so that a selection changed does not happen again
                //when exiting and re-entering the find customer page
            }
}
    }
}
