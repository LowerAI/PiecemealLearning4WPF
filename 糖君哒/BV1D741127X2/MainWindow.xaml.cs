using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BV1D741127X2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StringAnimationUsingKeyFrames MyAnimation = new StringAnimationUsingKeyFrames();

        public MainWindow()
        {
            InitializeComponent();
            MyAnimation.FillBehavior = FillBehavior.Stop;
            for (int i = 6; i >= 1; i--)
            {
                MyAnimation.KeyFrames.Add(
                    new DiscreteStringKeyFrame
                    {
                        Value = $"{i - 1}秒后再次获取",
                        KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6 - i))
                    }
                    );
            }
        }

        private void GetCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            GetCodeBtn.IsEnabled = false;
            GetCodeBtn.Foreground = Brushes.Black;
            MyAnimation.Completed += (s, args) =>
            {
                GetCodeBtn.IsEnabled = true;
                GetCodeBtn.Foreground = Brushes.White;
            };
            GetCodeBtn.BeginAnimation(Button.ContentProperty, MyAnimation);
        }
    }
}