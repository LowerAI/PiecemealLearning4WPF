using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            var offset = currentItem.TranslatePoint(new Point(0,0), PointerSlider).Y;
            var animation = new DoubleAnimation
            {
                To = offset,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            PointOffset.BeginAnimation(TranslateTransform.YProperty, animation);
        }
    }
}
