using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BV1XJ41127Dp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dma = new DoubleAnimation();
            dma.From = btn1.Width;
            dma.To = btn1.Width + 100;
            dma.Duration = TimeSpan.FromMilliseconds(500);

            //dma.AutoReverse = true; // 倒放的功能
            //dma.FillBehavior = FillBehavior.Stop; // 动画结束后立即恢复到默认状态
            //dma.RepeatBehavior = RepeatBehavior.Forever; // 无限循环此动画
            dma.RepeatBehavior = new RepeatBehavior(2); // 有限次的循环次数

            dma.Completed += Dma_Completed;

            btn1.BeginAnimation(Button.WidthProperty, dma);
            // dma.From  动画起始值
            // dma.To    动画结束值
            // dma.Duration  动画的持续时间
        }

        private void Dma_Completed(object sender, EventArgs e)
        {
            DoubleAnimation dma = new DoubleAnimation();
            dma.From = img.Width;
            dma.To = img.ActualWidth + 10;
            dma.Duration = TimeSpan.FromMilliseconds(500);
            dma.AutoReverse = true;
            dma.RepeatBehavior = RepeatBehavior.Forever;
            img.BeginAnimation(Image.WidthProperty, dma);
        }
    }
}
