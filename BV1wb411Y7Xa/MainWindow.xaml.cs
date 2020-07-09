using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BV1wb411Y7Xa
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

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            var MyButtonAnimation = new DoubleAnimation
            {
                From = 0,
                To = 720,
                Duration = new Duration(TimeSpan.Parse("00:00:04"))
            };

            MyButtonAnimation.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut };
            MyButtonRolate.BeginAnimation(RotateTransform.AngleProperty, MyButtonAnimation);
        }
    }
}
