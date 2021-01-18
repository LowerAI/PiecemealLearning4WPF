using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;

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
