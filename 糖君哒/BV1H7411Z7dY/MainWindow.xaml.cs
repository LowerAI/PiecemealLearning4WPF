using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BV1H7411Z7dY
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

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Fun_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btn_Min":
                    this.WindowState = WindowState.Minimized;
                    break;

                case "btn_Max":
                    this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                    break;

                case "btn_Off":
                    this.Close();
                    break;
            }
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Width + e.HorizontalChange > 0)
            {
                this.Width += e.HorizontalChange;
            }
            if (this.Height + e.VerticalChange > 0)
            {
                this.Height += e.VerticalChange;
            }
        }
    }
}
