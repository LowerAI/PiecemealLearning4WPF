using LiveCharts;
using LiveCharts.Wpf;
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

namespace BV1ft4y117Bo
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

        public SeriesCollection series { get; set; }

        public SeriesCollection series1 { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChartValues<double> arr = new ChartValues<double>();
            for (int i = 0; i < 1000; i++)
            {
                arr.Add(i);
            }

            series = new SeriesCollection();
            series.Add(new LineSeries
            {
                Values = arr
            });
            c1.Series = series;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
