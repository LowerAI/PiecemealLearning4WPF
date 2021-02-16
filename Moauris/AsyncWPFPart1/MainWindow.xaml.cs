using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncWPFPart1
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

        private Task[] PreparedTasks()
        {
            Progress<int> prog1 = new Progress<int>();
            Progress<int> prog2 = new Progress<int>();
            Progress<int> prog3 = new Progress<int>();

            prog1.ProgressChanged += (sender, args) =>
            {
                任务一进度条.Value = args;
            };
            prog2.ProgressChanged += (sender, args) =>
            {
                任务二进度条.Value = args;
            };
            prog3.ProgressChanged += (sender, args) =>
            {
                任务三进度条.Value = args;
            };
            //MessageBox.Show("进度报告完成，还未生成任务对象");
            Task[] tasks =
            {
                MyTestTasks.AsyncTaskOne(prog1),
                MyTestTasks.AsyncTaskOne(prog2, 300, 600),
                MyTestTasks.AsyncTaskOne(prog3, 10, 30)
            };
            //MessageBox.Show("任务构建完成，还未返回");
            return tasks;
        }

        private async void btnStartWhenAll_Click(object sender, RoutedEventArgs args)
        {
            Task[] tasks = PreparedTasks();
            await Task.WhenAll(tasks);

            MessageBox.Show("等待中的所有任务都完成了！");
            任务一进度条.Value = 0;
            任务二进度条.Value = 0;
            任务三进度条.Value = 0;
        }

        private async void btnStartWhenAny_Click(object sender, RoutedEventArgs e)
        {
            Task[] tasks = PreparedTasks();
            //await Task.WhenAny(tasks);
            var CompletedTask = await Task.WhenAny(tasks);

            if (CompletedTask == tasks[2])
            {
                MessageBox.Show("等待中的第三个任务完成了！");
            }

            //MessageBox.Show("等待中的某个任务完成了！");
            任务一进度条.Value = 0;
            任务二进度条.Value = 0;
            任务三进度条.Value = 0;
        }
    }

    public class MyTestTasks
    {
        public static async Task AsyncTaskOne(IProgress<int> progress = null, int LowRand = 30, int HighRand = 200)
        {
            Random rand = new Random();
            for (int i = 0; i <= 10; i++)
            {
                await Task.Delay(rand.Next(LowRand, HighRand));
                progress?.Report(i * 10);
            }
        }
    }
}
