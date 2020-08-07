using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

//using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BV1e54y1i7NF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timers = new DispatcherTimer();
        public double OffsetX { get; set; } = 0;
        public double OffsetY { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var PlaneMove = new DoubleAnimation
            //{
            //    Duration = TimeSpan.FromSeconds(3),
            //    To = Stage.ActualWidth - Plane.ActualWidth,
            //    From = 0,
            //    RepeatBehavior = RepeatBehavior.Forever,
            //    AutoReverse = true
            //};
            //Plane.BeginAnimation(Canvas.LeftProperty, PlaneMove);
            (Resources["ammo"] as Brush).Freeze(); // 释放画刷
            Timers.Tick += (a, b) =>
            {
                Move();
                Shoot();
            };
            Timers.Interval = TimeSpan.FromSeconds(0.1);
            Timers.Start();
        }

        /// <summary>
        /// 控制飞机移动
        /// </summary>
        //private void Window_KeyDown(object sender, KeyEventArgs e)
        private void Move()
        {
            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
            //if (e.Key == Key.W || e.Key == Key.Up)
            {
                var PlaneBottom = Canvas.GetBottom(Plane);
                var PlaneTop = PlaneBottom + Plane.ActualHeight;
                if (PlaneTop >= Stage.ActualHeight || double.IsNaN(PlaneTop))
                {
                    return;
                }
                Canvas.SetBottom(Plane, PlaneBottom + 10);
            }
            else if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
            //else if (e.Key == Key.S || e.Key == Key.Down)
            {
                var PlaneBottom = Canvas.GetBottom(Plane);
                if (PlaneBottom <= 0 || double.IsNaN(PlaneBottom))
                {
                    return;
                }
                Canvas.SetBottom(Plane, PlaneBottom - 10);
            }
            //else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            {
                var PlaneLeft = Canvas.GetLeft(Plane);
                if (PlaneLeft <= 0 || double.IsNaN(PlaneLeft))
                {
                    return;
                }
                Canvas.SetLeft(Plane, PlaneLeft - 10);
            }
            //else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                var PlaneLeft = Canvas.GetLeft(Plane);
                var PlaneRight = PlaneLeft + Plane.ActualWidth;
                if (PlaneRight >= Stage.ActualWidth || double.IsNaN(PlaneRight))
                {
                    return;
                }
                Canvas.SetLeft(Plane, PlaneLeft + 10);
            }
        }

        /// <summary>
        /// 控制飞机射击
        /// </summary>
        private void Shoot()
        {
            if (!Keyboard.IsKeyDown(Key.J))
            {
                return;
            }
            var ammoContainer = new Rectangle
            {
                Width = 10,
                Height = 30
            };
            ammoContainer.Fill = Resources["ammo"] as Brush;
            Canvas.SetLeft(ammoContainer, Canvas.GetLeft(Plane) + Plane.ActualWidth / 2 - 5); // 设置炮弹容器的左边线的横坐标
            Canvas.SetBottom(ammoContainer, Canvas.GetBottom(Plane) + Plane.ActualHeight); // 设置炮弹容器的底边线的纵坐标

            Stage.Children.Add(ammoContainer);

            var ammoMove = new DoubleAnimation
            {
                To = 1500,
                Duration = TimeSpan.FromSeconds(2)
            };

            ammoMove.Completed += (a, b) =>
            {
                Stage.Children.Remove(ammoContainer);
            };
            ammoContainer.BeginAnimation(Canvas.BottomProperty, ammoMove);
        }
    }
}