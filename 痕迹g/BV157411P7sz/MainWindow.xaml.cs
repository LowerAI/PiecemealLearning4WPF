using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BV157411P7sz
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

        //private void StackPanel_TouchMove(object sender, TouchEventArgs e)
        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            var stackPanel = sender as StackPanel;
            //var points = e.GetIntermediateTouchPoints(stackPanel);
            //if (points.Count < 2) return;
            //var first_point = points.First();
            //var last_point = points.Last();
            var first_point = stackPanel.TransformToAncestor(this).Transform(new Point(0, 0));
            var last_point = e.GetPosition(stackPanel);
            //if (first_point.Position.X == last_point.Position.X) return;
            if (first_point.X == last_point.X) return;
            var stackLength = stackPanel.Width;
            //var length = first_point.Position.X - last_point.Position.X;
            var length = first_point.X - last_point.X;
            if (length > 0) // 向左
            {
                var newrb_length = lb.Width - length;
                lb.Width = newrb_length > 0 ? newrb_length : 0;

                if (lb.Width == 0)
                {
                    rb.Width += length;
                }
            }
            else // 向右
            {
                var newb_length = rb.Width + length;
                rb.Width = newb_length > 0 ? newb_length : 0;

                if (lb.Width == 0)
                {
                    rb.Width -= length;
                }
            }
            var diff = stackLength - rb.Width;
            if (diff > 0)
            {
                element.Width = diff;
            }

            //if (rb.Width / stackLength > 0.4)
            //{
            //    MessageBox.Show("已删除");
            //}
            //else if (lb.Width / stackLength > 0.4)
            //{
            //    MessageBox.Show("已收藏");
            //}
            //}
        }

        //private void StackPanel_TouchLeave(object sender, TouchEventArgs e)
        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            rb.Width = 0;
            lb.Width = 0;
            element.Width = stackPanel.Width;
        }
    }
}
