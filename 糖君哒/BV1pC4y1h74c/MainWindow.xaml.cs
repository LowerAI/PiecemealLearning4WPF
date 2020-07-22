using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BV1pC4y1h74c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimeSpan LastFrameTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LastFrameTime = TimeSpan.Zero;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            var nextFrameTime = (e as RenderingEventArgs).RenderingTime;
            var deltaTime = nextFrameTime - LastFrameTime;
            LastFrameTime = nextFrameTime;

            #region 小车  开始

            var vectorW = new Vector(0, 0);
            var vectorS = new Vector(0, 0);
            var vectorA = new Vector(0, 0);
            var vectorD = new Vector(0, 0);

            if (Keyboard.IsKeyDown(Key.W))
            {
                vectorW.Y = -1;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                vectorS.Y = 1;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                vectorA.X = -1;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                vectorD.X = 1;
            }

            var result = vectorW + vectorS + vectorA + vectorD;
            if (result.X == 0 && result.Y == 0) return;
            result.Normalize();  // 重新单位化

            var speed = 200;
            if (Keyboard.IsKeyDown(Key.J)) speed = 400;

            var moveDirection = speed * deltaTime.TotalSeconds * result;

            Canvas.SetLeft(OldDriver, Canvas.GetLeft(OldDriver) + moveDirection.X);
            Canvas.SetTop(OldDriver, Canvas.GetTop(OldDriver) + moveDirection.Y);

            #endregion 小车  开始

            # region    坦克 开始
            var vectorUp = new Vector(0, 0);
            var vectorDown = new Vector(0, 0);
            var vectorLeft = new Vector(0, 0);
            var vectorRight = new Vector(0, 0);

            if (Keyboard.IsKeyDown(Key.Up))
            {
                vectorUp.Y = -1;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                vectorDown.Y = 1;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                vectorLeft.X = -1;
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                vectorRight.X = 1;
            }

            var resultTank = vectorUp + vectorDown + vectorLeft + vectorRight;
            if (resultTank.X == 0 && resultTank.Y == 0) return;
            resultTank.Normalize();  // 重新单位化

            TargetRotate.Angle = -Vector.AngleBetween(resultTank, new Vector(0, -1));

            var speedTank = 200;
            if (Keyboard.IsKeyDown(Key.J)) speedTank = 400;

            var moveTankDirection = speedTank * deltaTime.TotalSeconds * resultTank;

            Canvas.SetLeft(OldTank, Canvas.GetLeft(OldTank) + moveTankDirection.X);
            Canvas.SetTop(OldTank, Canvas.GetTop(OldTank) + moveTankDirection.Y);
            # endregion 坦克 结束
        }
    }
}