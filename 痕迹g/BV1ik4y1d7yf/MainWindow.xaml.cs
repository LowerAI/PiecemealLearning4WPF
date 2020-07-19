using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace BV1ik4y1d7yf
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

        private void benStart(object sender, RoutedEventArgs e)
        {
            #region 写法1 开始

            Storyboard sb = new Storyboard();
            sb.Children.Add(CreateDoubleAnimation(sample1, false, new RepeatBehavior(1), "Width", 30));
            sb.Children.Add(CreateDoubleAnimation(sample2, false, new RepeatBehavior(5), "Height", 30));
            sb.Children.Add(CreateDoubleAnimation(sample3, false, RepeatBehavior.Forever, "Width", 30));
            sb.Children.Add(CreateDoubleAnimation(sample4, false, RepeatBehavior.Forever, "Height", 30));
            sb.Begin();

            #endregion 写法1 开始

            #region 写法2 开始

            //sample1.BeginAnimation(Button.WidthProperty, da);

            #endregion 写法2 开始
        }

        private Timeline CreateDoubleAnimation(UIElement element, bool autoReverse, RepeatBehavior repeat, string propertyPath, double by)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            //da.To = 100;
            da.By = by;    // 在原有值上增加by
            da.Duration = TimeSpan.FromSeconds(1);
            da.RepeatBehavior = repeat;
            da.AutoReverse = autoReverse;

            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath(propertyPath));

            //Storyboard sb = new Storyboard();
            //sb.Children.Add(da);
            //sb.Begin();

            return da;
        }

        private void benStart1(object sender, RoutedEventArgs e)
        {
            //sample2_1.RenderTransform = new TranslateTransform(0, 0); // 支持位移
            //sample2_2.RenderTransform = new RotateTransform(0,0,0); // 支持旋转

            //DoubleAnimation da1 = new DoubleAnimation();
            //da1.By = 50;
            //da1.Duration = TimeSpan.FromSeconds(1);

            //DoubleAnimation da2 = new DoubleAnimation();
            //da2.By = 300;
            //da2.Duration = TimeSpan.FromSeconds(1);

            //Storyboard.SetTarget(da1, sample2_1);
            //Storyboard.SetTarget(da2, sample2_2);

            //Storyboard.SetTargetProperty(da1, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            //Storyboard.SetTargetProperty(da2, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            Storyboard sb = new Storyboard();
            //sb.Children.Add(da1);
            //sb.Children.Add(da2);

            sb.Children.Add(CreateDoubleAnimation(sample2_1, false, new RepeatBehavior(1), "(UIElement.RenderTransform).(TranslateTransform.X)", 30));
            sb.Children.Add(CreateDoubleAnimation(sample2_2, false, new RepeatBehavior(5), "(UIElement.RenderTransform).(TranslateTransform.Y)", 30));
            sb.Children.Add(CreateDoubleAnimation(sample2_3, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(RotateTransform.Angle)", 360));
            sb.Children.Add(CreateDoubleAnimation(sample2_4, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(TranslateTransform.X)", 60));

            sb.Begin();
        }

        private void benStart2(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();

            sb.Children.Add(CreateDoubleAnimation(sample3_1, false, new RepeatBehavior(1), "Opacity", 1));
            sb.Children.Add(CreateDoubleAnimation(sample3_2, false, new RepeatBehavior(5), "Opacity", 1));
            sb.Children.Add(CreateDoubleAnimation(sample3_3, true, RepeatBehavior.Forever, "Opacity", 1));
            sb.Children.Add(CreateDoubleAnimation(sample3_4, true, RepeatBehavior.Forever, "Opacity", 1));

            sb.Begin();
        }
    }
}