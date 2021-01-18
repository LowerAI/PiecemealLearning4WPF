using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BV12741117cE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Score = 264;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Score += 2;
            var target = Score.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            for (int i = 1; i <= 3; i++)
            {
                var animation = new DoubleAnimation
                {
                    From = new Random().Next(-400, 0),
                    To = (target[i - 1] + 1) * (-40),
                    Duration = new Duration(TimeSpan.FromSeconds(2))
                };
                animation.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut };
                (FindName($"trans{i}") as TranslateTransform).BeginAnimation(TranslateTransform.YProperty, animation);
            }
        }
    }
}
