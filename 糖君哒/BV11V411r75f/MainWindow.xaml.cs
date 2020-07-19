using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BV11V411r75f
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
            var animation = new DoubleAnimation();
            animation.From = -50;
            animation.To = 400;
            animation.Duration = new Duration(TimeSpan.FromSeconds(5));
            animation.RepeatBehavior = RepeatBehavior.Forever;
            ProgressRectange.BeginAnimation(TranslateTransform.XProperty, animation);
        }
    }
}