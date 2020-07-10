﻿using BV1XJ411Q7B2.ViewModel;
using System.Windows;

namespace BV1XJ411Q7B2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
        }
    }
}