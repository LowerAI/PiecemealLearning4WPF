using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BV1dh411k74E
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

        DispatcherTimer Creator = new DispatcherTimer(DispatcherPriority.Render);
        Random md = new Random();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Creator.Tick += Creator_Tick;
            Creator.Tick += Creator_Tick;
            Creator.Interval = TimeSpan.FromSeconds(0.1);
            Creator.Start();
        }

        private void Creator_Tick(object sender, EventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            var mousePosition = Mouse.GetPosition(MainContainer);
            var offsetVector = new Vector(md.Next(-25, 25), md.Next(-25, 25));
            var centerVector = new Vector(MainContainer.ActualWidth / 2, MainContainer.ActualHeight / 2);
            var resultVector = mousePosition + offsetVector - centerVector;

            var rect = new Rectangle();
            rect.StrokeThickness = md.Next(1, 6);
            rect.Stroke = Brushes.LightBlue;
            rect.SetBinding(HeightProperty, new Binding("Width") { Source = rect });
            var translate = new TranslateTransform()
            {
                X = resultVector.X,
                Y = resultVector.Y
            };
            rect.RenderTransform = translate;

            MainContainer.Children.Add(rect);
            var sizeAnimation = new DoubleAnimation()
            {
                From = 0,
                To = md.Next(40, 61),
                Duration = TimeSpan.FromMilliseconds(md.Next(500, 2000))
            };

            Storyboard.SetTargetProperty(sizeAnimation, new PropertyPath("Width"));

            var opacityAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = sizeAnimation.Duration
            };

            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("Opacity"));

            var storyBoard = new Storyboard();
            storyBoard.Children.Add(opacityAnimation);
            storyBoard.Children.Add(sizeAnimation);

            storyBoard.Completed += (s, args) =>
            {
                MainContainer.Children.Remove(rect);
            };

            rect.BeginStoryboard(storyBoard);
        }
    }
}
