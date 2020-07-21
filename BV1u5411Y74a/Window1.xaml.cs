using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BV1u5411Y74a
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            var StartPoint = new Point(0, -1);
            var EndPoint = new Point(e.GetPosition(Btn2).X, e.GetPosition(Btn2).Y);
            EndPoint.Offset(Btn2.ActualWidth / 2, Btn2.ActualHeight / 2);
            var CosinAngle = (StartPoint.X * EndPoint.X + StartPoint.Y * EndPoint.Y) / (Math.Sqrt(StartPoint.X * StartPoint.X + StartPoint.Y * StartPoint.Y) * Math.Sqrt(EndPoint.X * EndPoint.X + EndPoint.Y * EndPoint.Y));
            var SinAngle = Math.Sqrt(1 - CosinAngle * CosinAngle);
            if (EndPoint.X < 0)
            {
                SinAngle = -SinAngle;
            }
            var mx = new Matrix
            {
                M11 = CosinAngle,
                M12 = SinAngle,
                M21 = -SinAngle,
                M22 = CosinAngle
            };
            RenderMatrix.Matrix = mx;
        }
    }
}
