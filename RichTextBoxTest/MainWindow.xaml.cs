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

namespace RichTextBoxTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 0;

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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            OutputEcho(EchoContentType.Progress, count.ToString(), true);
            //TextPointer textPointer = rtb_Echo.Selection.Start;
            ////TextPointer lineStartPointer = textPointer.GetLineStartPosition(0);
            //textPointer.DeleteTextInRun(count.ToString().Length);
            count++;
            //textPointer.InsertTextInRun(count.ToString());
            //TextPointer prevPointer = textPointer.GetPositionAtOffset("<进度>".Length);
            //TextRange textRange = new TextRange(lineStartPointer, textPointer);
            //textRange.Text = "";
            ////在开始位置插入内容 
            //Run run = new Run("测试", tp0);
            //在插入内容的结尾到原来选中部分的结尾——原来选中部分的文字 清除掉 
            //TextPointer pointer = run.ContentEnd;
            //TextRange textRange = new TextRange(pointer, rtb_Echo.Selection.End);
            //textRange.Text = "";
            if (count % 10 == 0)
            {
                OutputEcho(EchoContentType.Wrap); 
            }
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
                    TextPointer selectionStartPointer = rtb_Echo.Selection.End;
                    TextPointer lineStartPointer = selectionStartPointer.GetLineStartPosition(0);
                    if (selectionStartPointer.LogicalDirection == LogicalDirection.Forward)
                    {
                        TextRange textRange = new TextRange(lineStartPointer, selectionStartPointer);
                        textRange.Text = "";
                        //selectionStartPointer.DeleteTextInRun(content.Length);
                        selectionStartPointer.InsertTextInRun(content); 
                    }
                    else
                    {
                        
                        Run run = new Run(content, lineStartPointer);
                        //在插入内容的结尾到原来选中部分的结尾——原来选中部分的文字 清除掉 
                        TextPointer pointer = run.ContentEnd;
                        TextRange textRange = new TextRange(pointer, selectionStartPointer);
                        textRange.Text = "";
                    }
                }
                else if (echoContentType == EchoContentType.Wrap)
                {
                    //rtb_Echo.AppendText("\n");
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
                }
                if (wrap)
                {
                    rtb_Echo.AppendText("\n");
                }
                rtb_Echo.ScrollToEnd();
            };

            if (sync)
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
