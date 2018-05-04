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
        StorageViewModel storageViewModel;
        public StorageFind()
        {
            InitializeComponent();
            storageViewModel = new StorageViewModel();
            DataContext = storageViewModel;
        }

        private void Button_Click_SearchMachines(object sender, RoutedEventArgs e)
        {
            storageViewModel.SearchMachines(SearchBox.Text);
        }
    }
}
