using GalaSoft.MvvmLight.Messaging;
using M3U8_Downloader.Models;
using M3U8_Downloader.ViewModel;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using System.Xml;
using WinForms = System.Windows.Forms;

namespace M3U8_Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer1 = new DispatcherTimer();
        private DispatcherTimer timer2 = new DispatcherTimer();

        // 1.定义委托  
        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);

        // 2.定义委托事件  
        //public event DelReadStdOutput ReadStdOutput;
        //public event DelReadErrOutput ReadErrOutput;

        private MainViewModel mvm = new MainViewModel();
        //private Downloader downloader = new Downloader();
        //任务栏进度条的实现。
        private TaskbarManager windowsTaskbar = TaskbarManager.Instance;
        private WinForms.FolderBrowserDialog fgDlg = new WinForms.FolderBrowserDialog();
        private IntPtr hwnd;

        private string houzhui = ".*";
        private string Command = "";

        int ffmpegid = -1;
        Double big = 0;
        Double small = 0;

        public MainWindow()
        {
            InitializeComponent();
            //HandyControl.Tools.ConfigHelper.Instance.SetWindowDefaultStyle();
            hwnd = new WindowInteropHelper(this).Handle; // this就是要获取句柄的窗体的类名；
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //3.将相应函数注册到委托事件中  
            //ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            //ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);

            timer1.Tick += Timer1_Tick;
            timer1.Interval = TimeSpan.FromSeconds(1);
            timer1.Start();

            timer2.Tick += Timer2_Tick; ;
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Start();

            Messenger.Default.Register<string>(this, "ODR", ReadStdOutputAction);
            Messenger.Default.Register<string>(this, "EDR", ReadErrOutputAction);
            Messenger.Default.Register<Func<IntPtr, bool, bool>>(this, "CPE", CmdProcessExited);
            this.DataContext = mvm;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("CurrentDomain_UnhandledException 异常已处理！");
            //e.Handled = true; //此异常已处理
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ////初始化进度条
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.Normal, hwnd);
            windowsTaskbar.SetProgressValue(0, 100, hwnd);

            if (!File.Exists(@"Tools\ffmpeg.exe"))  //判断程序目录有无ffmpeg.exe
            {
                MessageBox.Show("没有找到Tools\\ffmpeg.exe", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                //Dispose();
                //Application.Exit();
                Application.Current.Shutdown();
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\M3u8_Downloader_Settings.xml"))  //判断程序目录有无配置文件，并读取文件
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\M3u8_Downloader_Settings.xml");    //加载Xml文件  
                XmlNodeList topM = doc.SelectNodes("Settings");
                foreach (XmlElement element in topM)
                {
                    txtblk_DownloadPath.Text = element.GetElementsByTagName("DownPath")[0].InnerText;
                    var vft = element.GetElementsByTagName("ExtendName")[0].InnerText;
                    mvm.VideoFileType = (VideoFileType)Enum.Parse(typeof(VideoFileType), vft);
                    //if (element.GetElementsByTagName("ExtendName")[0].InnerText == "MP4") { rdbtn_mp4.IsChecked = true; }
                    //if (element.GetElementsByTagName("ExtendName")[0].InnerText == "MKV") { rdbtn_mkv.IsChecked = true; }
                    //if (element.GetElementsByTagName("ExtendName")[0].InnerText == "TS") { rdbtn_ts.IsChecked = true; }
                    //if (element.GetElementsByTagName("ExtendName")[0].InnerText == "FLV") { rdbtn_flv.IsChecked = true; }
                }
            }
            else  //若无配置文件，获取当前程序运行路径，即为默认下载路径
            {
                string lujing = Environment.CurrentDirectory;
                txtblk_DownloadPath.Text = lujing;
            }
        }

        private void txtblk_Adress_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
        }

        private void txtblk_Adress_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
        }

        private void txtblk_Adress_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                //获取拖拽的文件地址
                var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
                var hz = filenames[0].LastIndexOf('.') + 1;
                var houzhui = filenames[0].Substring(hz);//文件后缀名
                if (houzhui == "m3u8" || houzhui == "mkv" || houzhui == "avi" || houzhui == "mp4" || houzhui == "ts" || houzhui == "flv" || houzhui == "f4v" ||
                    houzhui == "wmv" || houzhui == "wm" || houzhui == "mpeg" || houzhui == "mpg" || houzhui == "m4v" || houzhui == "3gp" || houzhui == "rm" ||
                    houzhui == "rmvb" || houzhui == "mov" || houzhui == "qt" || houzhui == "m2ts" || houzhui == "m3u" || houzhui == "mts" || houzhui == "txt") //只允许拖入部分文件
                {
                    e.Effects = DragDropEffects.All;
                    string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                    txtblk_Adress.Text = path; //将获取到的完整路径赋值到textBox1
                }
            }
        }

        private void btn_Quit_Click(object sender, RoutedEventArgs e)
        {
            mvm.SaveSettings(txtblk_DownloadPath.Text);
            try
            {
                if (Process.GetProcessById(ffmpegid) != null)
                {
                    if (MessageBox.Show("已启动下载进程，确认退出吗？\n（这有可能是强制的）", "请确认您的操作", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        //Stop();
                        MessageBox.Show("已经发送命令！\n若进程仍然存在则强制结束！", "请确认");
                        try
                        {
                            if (Process.GetProcessById(ffmpegid) != null)  //如果进程还存在就强制结束它
                            {
                                Process.GetProcessById(ffmpegid).Kill();
                                //Dispose();
                                //Application.Exit();
                                Application.Current.Shutdown();
                            }
                        }
                        catch
                        {
                            //Dispose();
                            //Application.Exit();
                            Application.Current.Shutdown();
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
                //Dispose();
                //Application.Exit();
                Application.Current.Shutdown();
            }
        }

        private void btn_ChangePath_Click(object sender, RoutedEventArgs e)
        {
            if (fgDlg.ShowDialog() == WinForms.DialogResult.OK)
            {
                txtblk_DownloadPath.Text = fgDlg.SelectedPath;
            }
        }

        private void btn_OpenPath_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(txtblk_DownloadPath.Text);
        }

        private void hylnk_Stop_Click(object sender, RoutedEventArgs e)
        {
            mvm.Stop();
        }

        private void txtblk_Info_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (txtblk_Info.GetLineFromCharIndex(txtblk_Info.TextLength) + 1 > 14)
            //    txtblk_Info.ScrollBars = ScrollBars.Vertical;
            //if (txtblk_Info.GetLineFromCharIndex(txtblk_Info.TextLength) + 1 <= 14)
            //    txtblk_Info.ScrollBars = ScrollBars.None;

            Regex duration = new Regex(@"Duration: (\d\d[.:]){3}\d\d", RegexOptions.Compiled | RegexOptions.Singleline);//取总视频时长
            txtblk_TotalDuration.Text = "[总时长：" + duration.Match(txtblk_Info.Text).Value.Replace("Duration: ", "") + "]";
            Regex regex = new Regex(@"(\d\d[.:]){3}\d\d", RegexOptions.Compiled | RegexOptions.Singleline);//取视频时长以及Time属性
            var time = regex.Matches(txtblk_forRegex.Text);
            Regex size = new Regex(@"[1-9][0-9]{0,}kB time", RegexOptions.Compiled | RegexOptions.Singleline);//取已下载大小
            var sizekb = size.Matches(txtblk_forRegex.Text);
            if (time.Count > 0 && sizekb.Count > 0)
            {
                txtblk_Downloaded.Text = "[已下载：" + time.OfType<Match>().Last() + "，" + mvm.FormatFileSize(Convert.ToDouble(sizekb.OfType<Match>().Last().ToString().Replace("kB time", "")) * 1024) + "]";
            }

            Regex fps = new Regex(@", (\S+)\sfps", RegexOptions.Compiled | RegexOptions.Singleline);//取视频帧数
            Regex resolution = new Regex(@", \d{2,}x\d{2,}", RegexOptions.Compiled | RegexOptions.Singleline);//取视频分辨率
            txtblk_ViedoInfo.Text = "[视频信息：" + resolution.Match(txtblk_Info.Text).Value.Replace(", ", "") + "，" + fps.Match(txtblk_Info.Text).Value.Replace(", ", "") + "]";

            if (time.Count > 0 && sizekb.Count > 0)  //防止程序太快 无法截取
            {
                try
                {
                    Double All = Convert.ToDouble(Convert.ToDouble(txtblk_TotalDuration.Text.Substring(5, 2)) * 60 * 60 + Convert.ToDouble(txtblk_TotalDuration.Text.Substring(8, 2)) * 60
                + Convert.ToDouble(txtblk_TotalDuration.Text.Substring(11, 2)) + Convert.ToDouble(txtblk_TotalDuration.Text.Substring(14, 2)) / 100);
                    Double Downloaded = Convert.ToDouble(Convert.ToDouble(txtblk_Downloaded.Text.Substring(5, 2)) * 60 * 60 + Convert.ToDouble(txtblk_Downloaded.Text.Substring(8, 2)) * 60
                    + Convert.ToDouble(txtblk_Downloaded.Text.Substring(11, 2)) + Convert.ToDouble(txtblk_Downloaded.Text.Substring(14, 2)) / 100);

                    if (All == 0) All = 1;  //防止被除数为零导致程序崩溃
                    Double Progress = (Downloaded / All) * 100;

                    if (Progress > 100)  //防止进度条超过百分之百
                        Progress = 100;
                    if (Progress < 0)  //防止进度条小于零……
                        Progress = 0;

                    ProgressBar.Value = Convert.ToInt32(Progress);
                    windowsTaskbar.SetProgressValue(Convert.ToInt32(Progress), 100, hwnd);
                    txtblk_Progress.Visibility = Visibility.Visible;
                    txtblk_Progress.Text = "已完成：" + String.Format("{0:F}", Progress) + "%";
                    //this.Text = "已完成：" + String.Format("{0:F}", Progress) + "%" + " [" + mvm.FormatFileSize((big - small) * 1024) + "/s]";
                }
                catch (Exception)
                {
                    try
                    {
                        txtblk_TotalDuration.Text = "[总时长：NULL]";
                        Double Downloaded = Convert.ToDouble(Convert.ToDouble(txtblk_Downloaded.Text.Substring(5, 2)) * 60 * 60 + Convert.ToDouble(txtblk_Downloaded.Text.Substring(8, 2)) * 60
                    + Convert.ToDouble(txtblk_Downloaded.Text.Substring(11, 2)) + Convert.ToDouble(txtblk_Downloaded.Text.Substring(14, 2)) / 100);
                        Double Progress = 100;

                        if (Progress > 100)  //防止进度条超过百分之百
                            Progress = 100;
                        if (Progress < 0)    //防止进度条小于零……
                            Progress = 0;

                        ProgressBar.Value = Convert.ToInt32(Progress);
                        windowsTaskbar.SetProgressValue(Convert.ToInt32(Progress), 100, hwnd);
                        txtblk_Progress.Visibility = Visibility.Visible;
                        txtblk_Progress.Text = "已完成：" + String.Format("{0:F}", Progress) + "%";
                        //this.Text = "已完成：" + String.Format("{0:F}", Progress) + "%" + " [" + mvm.FormatFileSize((big - small) * 1024) + "/s]";
                    }
                    catch (Exception) { }
                }
            }
        }

        private void btn_Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_EXIT_Click(object sender, RoutedEventArgs e)
        {
            mvm.SaveSettings(txtblk_DownloadPath.Text);
            try
            {
                if (Process.GetProcessById(ffmpegid) != null)
                {
                    if (MessageBox.Show("已启动下载进程，确认退出吗？\n（这有可能是强制的）", "请确认您的操作", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        mvm.Stop();
                        MessageBox.Show("已经发送命令！\n若进程仍然存在则强制结束！", "请确认");
                        try
                        {
                            if (Process.GetProcessById(ffmpegid) != null)  //如果进程还存在就强制结束它
                            {
                                Process.GetProcessById(ffmpegid).Kill();
                                //Dispose();
                                //Application.Exit();
                                Application.Current.Shutdown();
                            }
                        }
                        catch
                        {
                            //Dispose();
                            //Application.Exit();
                            Application.Current.Shutdown();
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
                //Dispose();
                //Application.Exit();
                Application.Current.Shutdown();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            mvm.MoveFrom(hwnd);
        }

        private void hylnk_Monitor_Click(object sender, RoutedEventArgs e)
        {
            mvm.Exist_Run(@"Tools\HttpFileMonitor.exe");
        }

        private void hylnk_Merge_Click(object sender, RoutedEventArgs e)
        {
            mvm.Exist_Run(@"Tools\Batch Download.exe");
        }

        private void hylnk_WriteLog_Click(object sender, RoutedEventArgs e)
        {
            String LogName = "日志-" + System.DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + ".txt";
            StreamWriter log = new StreamWriter(LogName);
            log.WriteLine("━━━━━━━━━━━━━━\r\n"
                + "■M3U8 Downloader 用户日志\r\n\r\n"
                + "■" + DateTime.Now.ToString("F") + "\r\n\r\n"
                + "■输入：" + txtblk_Adress.Text + "\r\n\r\n"
                + "■输出：" + txtblk_DownloadPath.Text + "\\" + txtblk_Name.Text + houzhui + "\r\n\r\n"
                + "■FFmpeg命令：ffmpeg " + Command + "\r\n"
                + "━━━━━━━━━━━━━━"
                + "\r\n\r\n"
                + txtblk_Info.Text);
            log.Close();
            MessageBox.Show("日志已生成到程序目录！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void hylnk_ffmpeg_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ffmpeg.zeranoe.com/builds/win32/static/");
        }

        private void hylnk_Update_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://pan.baidu.com/s/1dF4uDuL");
        }

        private void hylnk_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("nilaoda 编译于 2016/10/22\nCopyright ©  2016", "关于", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void txtblk_Progress_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mvm.MoveFrom(hwnd);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Regex size = new Regex(@"[1-9][0-9]{0,}kB time", RegexOptions.Compiled | RegexOptions.Singleline);//取已下载大小
                var sizekb = size.Matches(txtblk_forRegex.Text);
                big = Convert.ToDouble(sizekb.OfType<Match>().Last().ToString().Replace("kB time", ""));

                txtblk_Downloaded.Text = "[" + mvm.FormatFileSize((big - small) * 1024) + "/s]";
            }
            catch (Exception) { }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            small = big;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mvm.SaveSettings(txtblk_DownloadPath.Text);
            try
            {
                if (Process.GetProcessById(ffmpegid) != null)
                {
                    if (MessageBox.Show("已启动下载进程，确认退出吗？\n（这有可能是强制的）", "请确认您的操作", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        mvm.Stop();
                        MessageBox.Show("已经发送命令！\n若进程仍然存在则强制结束！", "请确认");
                        try
                        {
                            if (Process.GetProcessById(ffmpegid) != null)  //如果进程还存在就强制结束它
                            {
                                Process.GetProcessById(ffmpegid).Kill();
                                //Dispose();
                                //Application.Exit();
                                Application.Current.Shutdown();
                            }
                        }
                        catch
                        {
                            //Dispose();
                            //Application.Exit();
                            Application.Current.Shutdown();
                        }
                    }
                    else
                    {
                        //e.Cancel = true;
                    }
                }
            }
            catch
            {
                //Dispose();
                //Application.Exit();
                Application.Current.Shutdown();
            }
        }

        private void btn_Download_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(txtblk_DownloadPath.Text))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(txtblk_DownloadPath.Text); //新建文件夹   
            }
            else
            {
                txtblk_Info.Text = "";
                txtblk_forRegex.Text = "";
                mvm.Download(txtblk_Adress.Text, txtblk_DownloadPath.Text, txtblk_Name.Text);
                txtblk_Stop.Visibility = Visibility.Visible;
                txtblk_ViedoInfo.Visibility = Visibility.Visible;
                txtblk_TotalDuration.Visibility = Visibility.Visible;
                txtblk_Downloaded.Visibility = Visibility.Visible;
                //label8.Visible = true;
                timer1.IsEnabled = true;
                timer2.IsEnabled = true;
            }
        }

        private void ReadStdOutputAction(string result)
        {
            txtblk_forRegex.Text = result;
            txtblk_Info.AppendText(result + "\r\n");
        }

        private void ReadErrOutputAction(string result)
        {
            txtblk_forRegex.Text = result;
            txtblk_Info.AppendText(result + "\r\n");
        }

        private void CmdProcessExited(Func<IntPtr, bool, bool> action)
        {
            action(hwnd, true);

            //设置任务栏进度条状态
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress, hwnd);
            this.Title = "M3U8 Downloader";
            txtblk_Progress.Text = "已完成：" + "100.00%";
            ProgressBar.Value = 100;
            timer1.IsEnabled = false;
            timer2.IsEnabled = false;
            //label8.Text = "";
            MessageBox.Show("命令执行结束！", "M3U8 Downloader", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);  // 执行结束后触发
        }
    }
}