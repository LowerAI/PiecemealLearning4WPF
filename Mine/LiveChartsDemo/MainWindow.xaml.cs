using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace LiveChartsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

            #region    c5 start
            Labels5 = new string[] { "数据1", "数据2", "数据3" };

            //添加两个纵坐标的单位
            FormatterT = value => value + "C°";
            FormatterS = value => value + "KB";

            templeseries.Title = "temp";
            //templeseries.LabelPoint = p => p.Y.ToString();
            //templeseries.LabelsPosition = BarLabelPosition.Top;
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

            var FillColors = new Color[] { Colors.Green, Colors.Blue, Colors.Pink, Colors.Yellow };
            IChartValues[] chartValues = new ChartValues<int>[]
            {
                new ChartValues<int> { 12, 14, 28, 62, 29, 29, 7, 31, 13, 11 },
                new ChartValues<int> { 45, 45, 23, 25, 25, 68, 4, 13, 46, 68 },
                new ChartValues<int> { 34, 4, 8, 35, 15, 83, 33, 33, 48, 61 },
                new ChartValues<int> { 22, 25, 17, 19, 34, 56, 39, 39, 48, 10 }
            };
            SeriesCollection6 = new SeriesCollection { };
            for (int i = 0; i < 4; i++)
            {
                ColumnSeries seriesPowerSave = new ColumnSeries();
                seriesPowerSave.Title = $"数据{i + 1}";
                //seriesPowerSave.Fill = new SolidColorBrush(Color.FromRgb(34, 139, 34));
                seriesPowerSave.Fill = new SolidColorBrush(FillColors[i]);
                seriesPowerSave.DataLabels = true;
                seriesPowerSave.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                //显示文本内容
                seriesPowerSave.LabelPoint = p => p.Y.ToString();
                seriesPowerSave.LabelsPosition = BarLabelPosition.Top;
                //seriesPowerSave.Values = new ChartValues<ObservablePoint>
                //{
                //    new ObservablePoint(0, 12),
                //    new ObservablePoint(1, 14),
                //    new ObservablePoint(2, 28),
                //    new ObservablePoint(3, 62),
                //    new ObservablePoint(4, 29),
                //    new ObservablePoint(5, 29),
                //    new ObservablePoint(6, 7),
                //    new ObservablePoint(7, 31),
                //    new ObservablePoint(8, 13),
                //    new ObservablePoint(9, 11)
                //};
                seriesPowerSave.Values = chartValues[i];

                //柱子宽度
                seriesPowerSave.Width = 20;
                seriesPowerSave.MaxColumnWidth = 20;

                SeriesCollection6.Add(seriesPowerSave);
            }
            #endregion c6 end

            DataContext = this;
        }
    }
}
