using System;
using System.Windows;
using System.Windows.Media;

namespace BV1fV411B7Fs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var angle = Math.PI / 6;
            var m = new Matrix(Math.Cos(angle), Math.Sin(angle), -Math.Sin(angle), Math.Cos(angle), 0, 0);
            var m2 = new Matrix(1, 0, 0, 1, 20, 20);
            CurrentTransform.Matrix = m2 * m * m2;
        }
    }
}