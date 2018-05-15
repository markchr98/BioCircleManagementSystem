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
    /// Interaction logic for StorageEditView.xaml
    /// </summary>
    public partial class StorageEditView : Page
    {
        StorageFindViewModel StorageFindViewModel;
        //StorageEditViewModel storageEditViewModel;
        public StorageEditView()
        {
            InitializeComponent();
            StorageFindViewModel = StorageFindViewModel.Instance;
            //storageEditViewModel = new StorageEditViewModel();
            DataContext = StorageFindViewModel;
        }

        private void Button_Click_UpdateCustomer(object sender, RoutedEventArgs e)
        {
            StorageFindViewModel.UpdateMachine();
            ((Window)this.Parent).Close();
        }
    }
}
