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
    /// Interaction logic for ContactPerson.xaml
    /// </summary>
    public partial class ContactPerson : System.Windows.Controls.UserControl
    {
        public ContactPerson()
        {
            InitializeComponent();
        }
        public void RemoveTextOnFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        public void Button_Click_ContactDelete(object sender, RoutedEventArgs e)
        {
            var contactParent = FindParent<ContactPerson>((Button)sender);
            var stackPanelParent = FindParent<StackPanel>(contactParent);
            stackPanelParent.Children.Remove(contactParent);            
        }

        private static T FindParent<T>(DependencyObject dependencyObject) where T: DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }
    }
}
