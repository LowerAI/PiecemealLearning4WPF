using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LiveChartsDemo
{
    /// <summary>
    /// MainWindow2.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow2 : Window
    {
        #region    属性 start
        /// <summary>
        /// 柱状图集合
        /// </summary>
        public SeriesCollection ColunmSeriesCollection0 { get; set; }

        /// <summary>
        /// 柱状图X坐标
        /// </summary>
        public string[] ColumnXLabels0 { get; set; }

        /// <summary>
        /// 柱状图集合
        /// </summary>
        public SeriesCollection ColunmSeriesCollection1 { get; set; }

        /// <summary>
        /// 柱状图X坐标
        /// </summary>
        public string[] ColumnXLabels1 { get; set; }

        /// <summary>
        /// 柱状图集合
        /// </summary>
        public SeriesCollection ColunmSeriesCollection2 { get; set; }

        /// <summary>
        /// 柱状图X坐标
        /// </summary>
        public string[] ColumnXLabels2 { get; set; }

        /// <summary>
        /// 柱状图集合
        /// </summary>
        public SeriesCollection ColunmSeriesCollection3 { get; set; }

        /// <summary>
        /// 柱状图X坐标
        /// </summary>
        public string[] ColumnXLabels3 { get; set; }

        /// <summary>
        /// 柱状图集合
        /// </summary>
        public SeriesCollection ColunmSeriesCollection4 { get; set; }

        /// <summary>
        /// 柱状图X坐标
        /// </summary>
        public string[] ColumnXLabels4 { get; set; }
        #endregion 属性 end

        public MainWindow2()
        {
            InitializeComponent();

            #region    GPS start
            ColumnXLabels0 = new string[] { "10", "20", "23", "29" };
            var FillColors0 = new Color[] { Colors.Green, Colors.Blue, Colors.Pink };
            var ColumnTitles0 = new string[] { "L1C/A", "L2C(M)", "L5(Q)" };
            IChartValues[] chartValues0 = new ChartValues<double>[]
            {
                new ChartValues<double> { 42.99, 30.71, 28.87, 37.45 },
                new ChartValues<double> { 34.92, 0, 34.61, 25.23 },
                new ChartValues<double> { 29.27, 0, 0, 0 }
            };
            ColunmSeriesCollection0 = GetColunmSeriesData(ColumnTitles0, FillColors0, chartValues0);
            #endregion GPS end

            #region    QZSS start
            ColumnXLabels1 = new string[] { "L1C/A", "L2C(M)", "L5(Q)" };
            var FillColors1 = new Color[] { Colors.Green, Colors.Blue, Colors.Pink };
            var ColumnTitles1 = new string[] { "193", "194", "195" };
            IChartValues[] chartValues1 = new ChartValues<double>[]
            {
                new ChartValues<double> { 31.82, 28.6, 33.96 },  // "L1C/A"
                new ChartValues<double> { 28.57, 22.99, 25.85 }, // "L2C(M)"
                new ChartValues<double> { 28.96, 0, 0 }          // "L5(Q)"
            };
            ColunmSeriesCollection1 = GetColunmSeriesData(ColumnTitles1, FillColors1, chartValues1);
            #endregion QZSS end

            this.DataContext = this;
        }

        SeriesCollection GetColunmSeriesData(string[] columnTitles, Color[] fillColors, IChartValues[] chartValues)
        {
            SeriesCollection SeriesCollection = new SeriesCollection();
            for (int i = 0; i < chartValues.Length; i++)
            {
                ColumnSeries seriesPowerSave = new ColumnSeries();
                seriesPowerSave.Title = columnTitles[i];
                seriesPowerSave.Fill = new SolidColorBrush(fillColors[i]);
                seriesPowerSave.DataLabels = true;
                //seriesPowerSave.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                //显示文本内容
                //seriesPowerSave.LabelPoint = p => p.Y.ToString();
                //seriesPowerSave.LabelsPosition = BarLabelPosition.Top;
                seriesPowerSave.Values = chartValues[i];

                //柱子宽度
                seriesPowerSave.Width = 20;
                seriesPowerSave.MaxColumnWidth = 20;

                SeriesCollection.Add(seriesPowerSave);
            }
            return SeriesCollection;
        }
    }
}
