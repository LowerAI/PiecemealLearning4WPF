using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BV11J411S7Zf
{
    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Message { get; set; } = "Message";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var loadAnimation = new DoubleAnimation();
            loadAnimation.Duration = new Duration(TimeSpan.Parse("0:0:1"));
            loadAnimation.From = 0.1;
            loadAnimation.To = 1;
            loadAnimation.EasingFunction = new ElasticEase
            {
                EasingMode = EasingMode.EaseOut,
                Springiness = 8
            };
            var loadClock = loadAnimation.CreateClock();
            scale.ApplyAnimationClock(ScaleTransform.ScaleXProperty, loadClock);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var unloadAnimation = new DoubleAnimation();
            unloadAnimation.Duration = new Duration(TimeSpan.Parse("0:0:0.3"));
            unloadAnimation.From = 1;
            unloadAnimation.To = 0.01;
            var unloadClock = unloadAnimation.CreateClock();
            unloadClock.Completed += (a, b) =>
            {
                DialogResult = true;
            };
            scale.ApplyAnimationClock(ScaleTransform.ScaleXProperty, unloadClock);
        }
    }
}