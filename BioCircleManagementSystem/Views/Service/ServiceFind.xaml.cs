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

namespace BioCircleManagementSystem.Views.Service
{
    /// <summary>
    /// Interaction logic for ServiceFind.xaml
    /// </summary>
    public partial class ServiceFind : Page
    {
        public ServiceFind()
        {
            InitializeComponent();
        }

        public static Uri Instance { get; internal set; }
    }
}
