using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;

namespace BV1cJ411Y7wW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            s1y.Separator.Step = 1; // 设置y轴数据间隔为1
            s2y.Separator.Step = 1; // 设置y轴数据间隔为1
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4, 6}
                }
            };

            string[] labels = new[] { "一月", "二月", "三月", "四月", "五月", };

            s1x.Labels = labels;
            s1.Series = series;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "深圳",
                    Values = new ChartValues<double> { 4, 6, 5, 2, 7}
                },
                new ColumnSeries
                {
                    Title = "广州",
                    Values = new ChartValues<double> { 6, 7, 3, 4, 6}
                }
            };

            string[] labels = new[] { "2011", "2012", "2013", "2014", "2015", };

            s2x.Labels = labels;
            s2.Series = series;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "深圳",
                    Values = new ChartValues<double> { 40 },
                    DataLabels = true,
                    LabelPoint = new Func<ChartPoint, string>((value) =>
                    {
                        return string.Format("{0}{1} ({2:P})", value.SeriesView.Title, value.Y, value.Participation);
                    })
                },
                new PieSeries
                {
                    Title = "广州",
                    Values = new ChartValues<double> { 40 },
                    DataLabels = true,
                    LabelPoint = new Func<ChartPoint, string>((value) =>
                    {
                        return string.Format("{0}{1} ({2:P})", value.SeriesView.Title, value.Y, value.Participation);
                    })
                },
                new PieSeries
                {
                    Title = "佛山",
                    Values = new ChartValues<double> { 20 },
                    DataLabels = true,
                    LabelPoint = new Func<ChartPoint, string>((value) =>
                    {
                        return string.Format("{0}{1} ({2:P})", value.SeriesView.Title, value.Y, value.Participation);
                    })
                }
            };

            s3.Series = series;
        }
    }
}