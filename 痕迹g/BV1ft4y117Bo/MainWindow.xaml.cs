using LiveCharts;
using LiveCharts.Wpf;
using System;
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

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        public SeriesCollection series { get; set; }

        public SeriesCollection series1 { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }

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

        private void Chart_onDataClick(object sender, ChartPoint chartPoint)
        {

        }
    }
}
