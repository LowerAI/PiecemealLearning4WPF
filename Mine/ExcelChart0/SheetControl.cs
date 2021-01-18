using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using System;
using Range = NetOffice.ExcelApi.Range;
//using Microsoft.Office.Interop.Excel;

namespace ExcelChart0
{
    class SheetControl
    {
        Worksheet sheet;
        public SheetControl(Worksheet sheet)
        {
            this.sheet = sheet;
        }

        /// <summary>
        /// 根据条件绘制图表
        /// </summary>
        /// <param name="rg">绘制图表的区域</param>
        /// <param name="data">数据区域</param>
        /// <param name="type">图表类型，XlChartType枚举类型</param>
        /// <param name="xlrc">设置以行或者列为系列，XlRowCol枚举类型</param>
        /// <param name="title">表格标题</param>
        /// <param name="CategoryTitle">表格分类坐标名称，即横坐标名称</param>
        /// <param name="ValueTitle">表格数据坐标的名称，即纵坐标名称</param>
        public void CreateChart(Range rg, Range data, Object type = null, XlRowCol xlrc = XlRowCol.xlColumns, string title = null, string CategoryTitle = null, string ValueTitle = null)
        {
            ChartObjects charts = (ChartObjects)sheet.ChartObjects(Type.Missing);
            ChartObject chartObj = charts.Add(Convert.ToDouble(rg.Left ?? 0d), Convert.ToDouble(rg.Top ?? 0d), Convert.ToDouble(rg.Width ?? 200d), Convert.ToDouble(rg.Height ?? 140d));
            Chart chart = chartObj.Chart;
            chart.ChartWizard(data, type, Type.Missing, xlrc, 1, 1, true, title, CategoryTitle, ValueTitle, Type.Missing);
            chart.Legend.Position = XlLegendPosition.xlLegendPositionTop;
        }

        /// <summary>
        /// 根据参数创建表格
        /// </summary>
        /// <param name="title">表格第一个单元格内容</param>
        /// <param name="rows">行标题，每行的首个单元格内容</param>
        /// <param name="cols">列标题，没列的首个单元格</param>
        /// <param name="data">表格数据</param>
        /// <param name="startRow">行开始位置</param>
        /// <param name="startCol">列开始位置</param>
        public void CreateTable(string title, string[] rows, string[] cols, string[,] data, int startRow, int startCol)
        {
            sheet.Cells[startRow, startCol].Value = title;
            for (int i = 0; i < cols.Length; i++)
            {
                sheet.Cells[startRow, i + startCol + 1].Value = cols[i];
            }
            for (int i = 0; i < rows.Length; i++)
            {
                sheet.Cells[i + startRow + 1, startCol].Value = rows[i];
                for (int j = 0; j < cols.Length; j++)
                {
                    sheet.Cells[i + startRow + 1, j + startCol + 1].Value = data[i, j];
                }
            }
        }

        /// <summary>
        /// 设置表格的信息，包括边框，文字等
        /// </summary>
        public void SetType()
        {

            sheet.UsedRange.Font.Size = 12;
            sheet.UsedRange.Font.Name = "华文楷体";
            sheet.UsedRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;//竖直居中
            sheet.UsedRange.VerticalAlignment = XlVAlign.xlVAlignCenter;//水平居中
            sheet.UsedRange.Borders.LineStyle = 1;//边框
            sheet.UsedRange.Columns.AutoFit();//列宽自适应
            sheet.UsedRange.Rows.AutoFit();//行高自适应
            //设置边框
            sheet.UsedRange.BorderAround(XlLineStyle.xlDouble, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, System.Drawing.Color.Black.ToArgb());
        }
    }
}