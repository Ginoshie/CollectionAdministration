﻿using System.Windows;

namespace CollectionAdministration_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new CollectionAdministrationViewModel();
        }
    }
}
