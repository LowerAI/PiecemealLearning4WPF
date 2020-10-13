using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BV1bi4y1j7Wz
{
    public class GridLinePanel : Control
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);
            var p = new Pen(Brushes.Blue, 2);
            var pos = Mouse.GetPosition(this);
            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(0, 0, ActualWidth, ActualHeight)); // 绘制矩形衬底
            drawingContext.DrawLine(p, new Point(0, pos.Y), new Point(ActualWidth, pos.Y));  // 绘制横线
            drawingContext.DrawLine(p, new Point(pos.X, 0), new Point(pos.X, ActualHeight));  // 绘制竖线
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            InvalidateVisual();   // 鼠标移动时指示自动绘制作废强制调用覆写的手动绘制
        }
    }
}
