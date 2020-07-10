using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BV1bJ411D7U3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int TimerSet = 200;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var thisTimer = new Timer(TimerSet);
            thisTimer.Elapsed += UpdateMoveDirection;
            thisTimer.Start();
        }

        private void UpdateMoveDirection(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                var MouseLocation = Mouse.GetPosition(ThisCanvas); // 鼠标指针的坐标
                if (MouseLocation.X < 0 || MouseLocation.Y < 0)
                {// 指针超出画布时让球停止运动
                    return;
                }
                var MouseVector = Vector.Parse(MouseLocation.ToString()); // 鼠标位置转换为鼠标向量
                var TargetVector = Vector.Parse(Target.Center.ToString()); // 获取球的位置
                var DirectionVector = MouseVector - TargetVector; // 生成方向向量
                if (DirectionVector.Length < 10)
                {// 球与指针重合时停止晃动
                    return;
                }
                DirectionVector.Normalize(); // 向量单位化
                var thisPointAnimation = new PointAnimation()
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(TimerSet)),
                    By = new Point(DirectionVector.X * 20, DirectionVector.Y * 20)
                };
                Target.BeginAnimation(EllipseGeometry.CenterProperty, thisPointAnimation);
            }));
        }
    }
}
