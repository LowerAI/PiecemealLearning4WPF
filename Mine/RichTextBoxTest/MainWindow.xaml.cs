using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RichTextBoxDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 0;

        /// <summary>
        /// 指令内容类型
        /// </summary>
        public enum InstructionType
        {
            /// <summary>
            /// 显示板卡串口
            /// </summary>
            ShowCOM = 0,
            /// <summary>
            /// 进入下载全部固件模式
            /// </summary>
            DownloadFullFirmwareMode = 1,
            /// <summary>
            /// 进入写号模式
            /// </summary>
            WriteNumberMode = 2,
            /// <summary>
            /// 写号
            /// </summary>
            WriteNumber = 3,
            /// <summary>
            /// 查看写号
            /// </summary>
            ShowNumber = 4,
            /// <summary>
            /// 永久保存写号
            /// </summary>
            SaveNumberForever = 5,
            /// <summary>
            /// 复位
            /// </summary>
            Reset = 6,
            /// <summary>
            /// 强制复位
            /// </summary>
            ForceReset = 7,
            /// <summary>
            /// 设置板卡当前串口波特率
            /// </summary>
            SetCOMBaudRate = 8
        }

        /// <summary>
        /// 回显内容类型
        /// </summary>
        private enum EchoContentType
        {
            /// <summary>
            /// 标题
            /// </summary>
            Title,
            /// <summary>
            /// 正文
            /// </summary>
            Body,
            /// <summary>
            /// 结论-成功
            /// </summary>
            Success,
            /// <summary>
            /// 结论-失败
            /// </summary>
            Fail,
            /// <summary>
            /// 警告
            /// </summary>
            Warning,
            /// <summary>
            /// 错误
            /// </summary>
            Error,
            /// <summary>
            /// 进度条
            /// </summary>
            Progress,
            /// <summary>
            /// 分割线
            /// </summary>
            Splitters,
            /// <summary>
            /// 换行符
            /// </summary>
            Wrap
        }

        #region    字典 start
        /// <summary>
        /// 指令字典
        /// </summary>
        public Dictionary<InstructionType, string> dictInstruction = new Dictionary<InstructionType, string>
        {
            { InstructionType.ShowCOM, "com" },
            { InstructionType.DownloadFullFirmwareMode, "$#**#x{baudrate}!" },
            { InstructionType.WriteNumberMode, "$*##*PNSN#**#" },
            { InstructionType.WriteNumber, "pn {pn} sn {sn}" },
            { InstructionType.ShowNumber, "showpnsn" },
            { InstructionType.Reset, "reset" },
            { InstructionType.ForceReset, "freset" },
            { InstructionType.SetCOMBaudRate, "com {com} {baudrate}" }
        };

        public Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "key", "value" }
        };
        #endregion 字典 end

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SerialPort serialPort = new SerialPort();
            //serialPort
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            //string instruction = dictInstruction[InstructionType.Reset];
            Action action = () =>
            {
                //OutputEcho(EchoContentType.Title, count.ToString(), true);
                OutputEcho(EchoContentType.Progress, count.ToString(), true);
                count++;
            };

            //Action action1 = () =>
            //{
            //    for (int i = 0; i <= 1000000; i++)
            //    {
            //        this.Dispatcher.BeginInvoke(action);
            //    }
            //};
            Task.Factory.StartNew(action);

            //for (int i = 0; i <= 1000000; i++)
            //{
            //    //Thread.Sleep(500);
            //    //this.Dispatcher.BeginInvoke(action);
            //}
                        
            //if (count % 10 == 0)
            //{
            //    OutputEcho(EchoContentType.Wrap);
            //}
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rtb_Echo.Document.Blocks.Clear();
        }

        /// <summary>
        /// 输出回显内容到回显框
        /// </summary>
        /// <param name="echoContentType">回显内容类型</param>
        /// <param name="text">回显内容</param>
        /// <param name="sync">是否同步调用</param>
        /// <param name="wrap">是否自动换行</param>
        private void OutputEcho(EchoContentType echoContentType, string text = "", bool sync = false, bool wrap = false)
        {
            string content = "";
            char separator = '-';
            int separatorCount = 18; // 分隔符的数量
            string foreground = "black";
            //string background = "transparent";
            int fontSize = 20;
            switch (echoContentType)
            {
                case EchoContentType.Title:
                    content = text;
                    foreground = "blue";
                    fontSize = 30;
                    break;
                case EchoContentType.Success:
                    separator = '√';
                    separatorCount = 15;
                    content = text;
                    foreground = "green";
                    fontSize = 35;
                    break;
                case EchoContentType.Fail:
                    separator = '✕';
                    separatorCount = 10;
                    content = text;
                    foreground = "red";
                    fontSize = 35;
                    break;
                case EchoContentType.Warning:
                    separator = '#';
                    separatorCount = 10;
                    content = text;
                    foreground = "yellow";
                    fontSize = 35;
                    break;
                case EchoContentType.Error:
                    separator = 'ㄨ';
                    separatorCount = 10;
                    content = text;
                    foreground = "red";
                    fontSize = 35;
                    break;
                case EchoContentType.Splitters:
                    content = new string('-', 80);
                    foreground = "black";
                    fontSize = 20;
                    break;
                case EchoContentType.Body:
                default:
                    content = text;
                    foreground = "black";
                    break;
            }

            Action action = () =>
            {
                if (echoContentType == EchoContentType.Progress)
                {
                    //var parent = rtb_Echo.Selection.Start.Parent;
                    //if (parent is Run)
                    //{
                    //    ((Run)parent).Text = content;
                    //}
                    //else if (parent is FlowDocument)
                    //{
                    //    Run run = new Run(content, rtb_Echo.Selection.Start);
                    //}
                    //var pb = rtb_Echo.FindName("pb_ffw");
                    object pb = null;
                    var blockObj = rtb_Echo.Document.Blocks.FirstOrDefault((block) =>
                    {
                        Paragraph paragraph = block as Paragraph;
                        var pgh = paragraph.Inlines.FirstOrDefault((inline) =>
                        {
                            pb = inline.FindName("pb_ffw");
                            return pb == null;
                        });
                        return pgh == null;
                    });
                    if (pb == null)
                    {
                        ProgressBar progressBar = new ProgressBar();
                        progressBar.Name = "pb_ffw";
                        progressBar.Value = 80;
                        progressBar.Maximum = 100;
                        progressBar.Height = 50;
                        progressBar.Width = 300;
                        InlineUIContainer inline = new InlineUIContainer(progressBar);
                        Paragraph paragraph = new Paragraph();
                        paragraph.Inlines.Add(inline);
                        rtb_Echo.Document.Blocks.Add(paragraph); 
                    }
                    else
                    {
                        ProgressBar progressBar = pb as ProgressBar;
                        progressBar.Value += 81;
                    }
                }
                else if (echoContentType == EchoContentType.Wrap)
                {
                    TextPointer textPointer = rtb_Echo.Selection.Start;
                    textPointer.InsertLineBreak();
                }
                else
                {
                    Run run = new Run
                    {
                        Text = content,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(foreground)),
                        //Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(background)),
                        FontSize = fontSize
                    };

                    Paragraph paragraph = new Paragraph();
                    if (echoContentType == EchoContentType.Title || echoContentType == EchoContentType.Success || echoContentType == EchoContentType.Fail || echoContentType == EchoContentType.Warning || echoContentType == EchoContentType.Error)
                    {
                        string txt = new string(separator, separatorCount);
                        Run runSeparator1 = new Run(txt);
                        paragraph.Inlines.Add(runSeparator1);
                        paragraph.Inlines.Add(run);
                        Run runSeparator2 = new Run(txt);
                        paragraph.Inlines.Add(runSeparator2);
                    }
                    else
                    {
                        paragraph.Inlines.Add(run);
                    }

                    rtb_Echo.Document.Blocks.Add(paragraph);
                    //rtb_Echo.Selection.ApplyPropertyValue(TextElement.FontStretchProperty, FontStretch.FromOpenTypeStretch(3));
                }
                if (wrap)
                {
                    rtb_Echo.AppendText("\n");
                }
                rtb_Echo.ScrollToEnd();
            };

            //if (sync)
            if (rtb_Echo.CheckAccess())
            {
                action();
            }
            else
            {
                rtb_Echo.Dispatcher.Invoke(action);
            }
        }
    }
}
