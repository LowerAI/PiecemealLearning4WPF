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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BV1gE411c7Zq
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var layer = AdornerLayer.GetAdornerLayer(mybutton);
            //layer.Add(new TestAdorner(mybutton));

            foreach (UIElement item in mypanel.Children)
            {
                var layer = AdornerLayer.GetAdornerLayer(item);
                layer.Add(new TestAdorner(item));
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //var layer = AdornerLayer.GetAdornerLayer(mybutton);
            //var arr = layer.GetAdorners(mybutton);
            //if (arr != null)
            //{
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        layer.Remove(arr[i]);
            //    }
            //}

            foreach (UIElement item in mypanel.Children)
            {
                var layer = AdornerLayer.GetAdornerLayer(item);
                var arr = layer.GetAdorners(item);
                if (arr != null)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        layer.Remove(arr[i]);
                    }
                }
            }
        }
    }
}
