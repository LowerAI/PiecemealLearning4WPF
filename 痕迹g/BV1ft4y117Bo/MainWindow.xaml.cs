using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace BV1ft4y117Bo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection series { get; set; }
        public SeriesCollection series1 { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        List<double> filesize = new List<double>();
        List<double> temperature = new List<double>();
        ColumnSeries sizeseries = new ColumnSeries(); //新建一条文件大小的柱状图
        ColumnSeries templeseries = new ColumnSeries(); //新建一条温度的柱状图
        public Func<double, string> FormatterT { get; set; }
        public Func<double, string> FormatterS { get; set; }
        public SeriesCollection SeriesCollection5 { get; set; }
        public string[] Labels5 { get; set; }

        public SeriesCollection SeriesCollection6 { get; set; }
        public string[] Labels6 { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            #region    c4 start
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            #endregion c4 end

            #region    c5 start
            Labels5 = new string[] { "数据1", "数据2", "数据3" };

            //添加两个纵坐标的单位
            FormatterT = value => value + "C°";
            FormatterS = value => value + "KB";

            templeseries.Title = "temp";
            //温度的柱状图依赖于第一条纵坐标
            templeseries.ScalesYAt = 0; // 左Y轴
            axisT.Title = "temp/C°";

            sizeseries.Title = "size";
            //文件大小的柱状图依赖于第二条纵坐标
            sizeseries.ScalesYAt = 1; // 右Y轴
            axisS.Title = "size/KB";

            temperature = new List<double> { 30, 27.5, 29.8 };
            filesize = new List<double> { 20, 10, 9 };

            templeseries.Values = new ChartValues<double>(temperature);
            sizeseries.Values = new ChartValues<double>(filesize);

            SeriesCollection5 = new SeriesCollection { };
            SeriesCollection5.Add(templeseries);
            SeriesCollection5.Add(sizeseries);
            #endregion c5 end

            #region    c6 start
            Labels6 = new string[] { "09-01", "09-02", "09-03", "09-04", "09-05", "09-06", "09-07", "09-08", "09-09", "09-10" };

            ColumnSeries seriesPowerSave = new ColumnSeries();
            seriesPowerSave.Title = "数据1";
            seriesPowerSave.Fill = new SolidColorBrush(Color.FromRgb(34, 139, 34));
            seriesPowerSave.DataLabels = true;
            seriesPowerSave.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //显示文本内容
            seriesPowerSave.LabelPoint = p => p.Y.ToString();
            seriesPowerSave.Values = new ChartValues<ObservablePoint>
            {
                new ObservablePoint(0, 12),
                new ObservablePoint(1, 14),
                new ObservablePoint(2, 28),
                new ObservablePoint(3, 62),
                new ObservablePoint(4, 29),
                new ObservablePoint(5, 29),
                new ObservablePoint(6, 7),
                new ObservablePoint(7, 31),
                new ObservablePoint(8, 13),
                new ObservablePoint(9, 11)
            };

            //柱子宽度
            seriesPowerSave.Width = 20;
            seriesPowerSave.MaxColumnWidth = 20;

            SeriesCollection6 = new SeriesCollection{ };
            SeriesCollection6.Add(seriesPowerSave);
            #endregion c6 end

            DataContext = this;
        }

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
