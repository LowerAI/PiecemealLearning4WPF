using System;
using System.Windows;
using System.Windows.Input;

namespace BV1u5411Y74a
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

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            var StartPoint = new Point(0, -1);
            var EndPoint = new Point(e.GetPosition(Btn2).X, e.GetPosition(Btn2).Y);
            EndPoint.Offset(Btn2.ActualWidth / 2, Btn2.ActualHeight / 2);
            var CosinAngle = (StartPoint.X * EndPoint.X + StartPoint.Y * EndPoint.Y) / (Math.Sqrt(StartPoint.X * StartPoint.X + StartPoint.Y * StartPoint.Y) * Math.Sqrt(EndPoint.X * EndPoint.X + EndPoint.Y * EndPoint.Y));
            if (EndPoint.X < 0)
            {
                Rotate.Angle = 360 - Math.Acos(CosinAngle) / Math.PI * 180;
            }
            else
            {
                Rotate.Angle = Math.Acos(CosinAngle) / Math.PI * 180;
            }
        }
    }
}
