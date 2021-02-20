using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;

namespace LiveChartsDemo
{
    /// <summary>
    /// 原文链接[LiveCharts 折线图，柱状图，饼状图基本绑定实现(WPF) - ICU的个人空间 - OSCHINA - 中文开源技术交流社区](https://my.oschina.net/u/2525682/blog/3207803)
    /// </summary>
    public partial class MainWindow1 : Window
    {
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        public MainWindow1()
        {
            InitializeComponent();
            this.DataContext = mainWindowViewModel;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
