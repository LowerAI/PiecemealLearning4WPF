using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BV1Pv411e7KL
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

        List<ContentControl> AnchoredPoints = new List<ContentControl>();
        Line CurrentLine;

        private void MainContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ContentControl anchor)
            {
                CreateLine(anchor);
            }
        }

        private void MainContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LineContainer.Children.Clear();
            AnchoredPoints.Clear();
            CurrentLine = null;
        }

        private void MainContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentLine == null) return;
            if (e.Source is ContentControl anchor && !AnchoredPoints.Contains(anchor))
            {
                var position = anchor.TranslatePoint(new Point(50, 50), MainContainer);
                CurrentLine.X2 = position.X;
                CurrentLine.Y2 = position.Y;
                CreateLine(anchor);
            }
            else
            {
                var mousePosition = e.GetPosition(MainContainer);
                CurrentLine.X2 = mousePosition.X;
                CurrentLine.Y2 = mousePosition.Y;
            }
        }

        private void CreateLine(ContentControl anchor)
        {
            var position = anchor.TranslatePoint(new Point(50,50), MainContainer);
            CurrentLine = new Line()
            {
                X1 = position.X,
                Y1 = position.Y,
                X2 = position.X,
                Y2 = position.Y,
                Stroke = Brushes.White,
                StrokeThickness = 10,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round
            };
            LineContainer.Children.Add(CurrentLine);
        }
    }
}
