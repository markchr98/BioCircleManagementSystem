﻿using BioCircleManagementSystem.ViewModels;
using BioCircleManagementSystem.Views.Resources.Notifications;
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

namespace BioCircleManagementSystem.Views.Storage
{
    /// <summary>
    /// Interaction logic for StorageCreate.xaml
    /// </summary>
    public partial class StorageCreate : Page
    {
        public StorageCreate()
        {
            InitializeComponent();
            DataContext = new StorageViewModel();
        }
    }
}
