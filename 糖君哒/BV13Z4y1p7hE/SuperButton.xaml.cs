using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BV13Z4y1p7hE
{
    /// <summary>
    /// SuperButton.xaml 的交互逻辑
    /// </summary>
    public partial class SuperButton : Button
    {
        public SuperButton()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = Template.FindName("MyEllipse", this) as EllipseGeometry;
            target.Center = Mouse.GetPosition(this);  // 获取当前鼠标指针的坐标
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 150,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };
            target.BeginAnimation(EllipseGeometry.RadiusXProperty, animation);

            var animation1 = new DoubleAnimation
            {
                From = 0.3,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };
            var target1 = Template.FindName("MyPath", this) as Path;
            target1.BeginAnimation(Path.OpacityProperty, animation1);
        }
    }
}
