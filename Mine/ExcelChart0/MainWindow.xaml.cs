using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using System;
using System.Reflection;
using System.Windows;
using Excel = NetOffice.ExcelApi;
using Range = NetOffice.ExcelApi.Range;

namespace ExcelChart0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public Excel.Application myexcel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMake_Click(object sender, RoutedEventArgs e)
        {
            string[] rows = { "国家机关办公建筑", "办公建筑", "商场建筑", "宾馆饭店建筑", "文化建筑", "医疗卫生建筑", "体育建筑", "综合建筑", "教育建筑", "其他建筑", "总计" };
            string[] cols = { "本月", "上月" };
            string[,] data ={{"3","5"},
                            {"0","66"},
                            {"1","36"},
                            {"2","27"},
                            {"0","7"},
                            {"2","2"},
                            {"0","2"},
                            {"0","29"},
                            {"0","2"},
                            {"0","2"},
                            {"8","178"}};

            MessageBoxResult res = MessageBox.Show("是否生成 新的Excel ?", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                myexcel = new Excel.Application();
                myexcel.DisplayAlerts = false;
                myexcel.Application.Workbooks.Add(Type.Missing);
                myexcel.Caption = "excel test";
                myexcel.Visible = true;
                Worksheet sheet = (Worksheet)myexcel.ActiveWorkbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                sheet.Name = "表2";
                SheetControl sc = new SheetControl(sheet);
                sc.CreateChart(sheet.get_Range("F2:O12"), sheet.get_Range((Range)sheet.Cells[2, 2], (Range)sheet.Cells[2 + rows.Length - 1, 2 + cols.Length]), XlChartType.xlColumnClustered, XlRowCol.xlColumns, "本月建筑能耗监测情况", null, "月度单位面积电耗");
                //sheet.get_Range(sheet.Cells[2,2],sheet.Cells[2+rows.Length,2+cols.Length])
                sc.CreateTable("建筑类型", rows, cols, data, 2, 2);
                sc.SetType();
            }
        }
    }
}
