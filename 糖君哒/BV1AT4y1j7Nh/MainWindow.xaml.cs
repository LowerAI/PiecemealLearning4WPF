using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BV1AT4y1j7Nh
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

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            var currentItem = sender as ListBoxItem;
            var offset = currentItem.TranslatePoint(new Point(0, 0), PointerSlider).Y;
            var animation = new DoubleAnimation
            {
                To = offset,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            PointOffset.BeginAnimation(TranslateTransform.YProperty, animation);
        }
    }
}
