using System.Windows;

namespace BV1zK4y1s78p
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var BVector = new Vector(-Earth.Width / 2, -Earth.Height / 2);
            var p = Sun.TranslatePoint(new Point(Sun.Width / 2, Sun.Height / 2), Earth);
            var CVector = new Vector(p.X, p.Y);
            var AVector = BVector + CVector;
            var NewPoint = new Point(AVector.X, AVector.Y);
            EarthRotate.CenterX = NewPoint.X;
            EarthRotate.CenterY = NewPoint.Y;
        }
    }
}