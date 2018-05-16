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

namespace BioCircleManagementSystem.Views.Storage
{
    /// <summary>
    /// Interaction logic for StorageFind.xaml
    /// </summary>
    public partial class StorageFind : Page
    {
        private static StorageFind _instance;
        public static StorageFind Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StorageFind();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        StorageFindViewModel storageFindViewModel;
        public StorageFind()
        {
            InitializeComponent();
            storageFindViewModel = StorageFindViewModel.Instance;
            DataContext = storageFindViewModel;
        }

        private void Button_Click_SearchMachines(object sender, RoutedEventArgs e)
        {
            storageFindViewModel.SearchMachines(SearchBox.Text);
        }

        private void machines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if statement to prevent endless loop caused by UnselectAll() causing a slectionChanged event
            if (machines.SelectedItem != null)
            {
                //Might be changed to page with navigation in frame 
                StorageEditView SEV = new StorageEditView();
                ShellWindow window = new ShellWindow();
                window.WindowState = WindowState.Normal;
                window.Content = SEV;
                window.ShowDialog();
                window.Height = 450;
                window.Width = 900;
                machines.UnselectAll();
                //Unselect current item so that a selection changed does not happen again
                //when exiting and re-entering the find customer page
            }
        }
    }
}
