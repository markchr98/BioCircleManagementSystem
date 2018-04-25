﻿using System;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    
    //refering to System.Windows.Controls.UserControl becaue of same name as folder and build errors when editing folder
    public partial class UserControl1 :  System.Windows.Controls.UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void RemoveTextOnFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
    }
}