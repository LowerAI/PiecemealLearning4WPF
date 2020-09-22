using M3U8_Downloader.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace M3U8_Downloader
{
    public class Downloader
    {
        //拖动窗口
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        [DllImport("kernel32.dll")]
        static extern bool GenerateConsoleCtrlEvent(int dwCtrlEvent, int dwProcessGroupId);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(IntPtr handlerRoutine, bool add);
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        int ffmpegid = -1;
        Double big = 0;
        Double small = 0;

        // 1.定义委托  
        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);

        // 2.定义委托事件  
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;

        private void Exist_Run(string FileName)
        {
            if (File.Exists(FileName))  //判断有无某文件
            {
                Process.Start(FileName);
            }
            else
            {
                //MessageBox.Show("没有找到" + FileName, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 移动窗口
        public void MoveFrom(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        public void SaveSettings(VideoFileType videoFileType, string downloadPath)
        {
            //string ExtendName = "";
            //if (radioButton1.Checked == true) { ExtendName = "MP4"; }
            //if (radioButton2.Checked == true) { ExtendName = "MKV"; }
            //if (radioButton3.Checked == true) { ExtendName = "TS"; }
            //if (radioButton4.Checked == true) { ExtendName = "FLV"; }
            string ExtendName = videoFileType.ToString();

            XmlTextWriter xml = new XmlTextWriter(@System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\M3u8_Downloader_Settings.xml", Encoding.UTF8);
            xml.Formatting = Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("Settings");

            //xml.WriteStartElement("DownPath"); xml.WriteCData(textBox_DownloadPath.Text); xml.WriteEndElement();
            xml.WriteStartElement("DownPath"); xml.WriteCData(downloadPath); xml.WriteEndElement();
            xml.WriteStartElement("ExtendName"); xml.WriteCData(ExtendName); xml.WriteEndElement();

            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();
            xml.Close();
        }

        public void Download(VideoFileType videoFileType, string downloadAddress, string downloadPath, string fileName)
        {
            string cmdCore = "";
            switch (videoFileType)
            {
                case VideoFileType.FLV:
                    cmdCore = "-bsf:a aac_adtstoasc -movflags +faststart";
                    break;
                case VideoFileType.MP4:
                    cmdCore = "-bsf:a aac_adtstoasc";
                    break;
                case VideoFileType.MKV:
                    cmdCore = "-f mpegts";
                    break;
                case VideoFileType.TS:
                    cmdCore = "-f f4v -bsf:a aac_adtstoasc";
                    break;
                default:
                    break;
            }
            string fileExt = videoFileType.ToString();
            string fileFullPath = $"{downloadPath}\\{fileName}.{fileExt}";
            string cmdText = $"-threads 0 -i \"{downloadAddress}\" -c copy -y {cmdCore} \"{fileFullPath}\"";
            RealAction(@"Tools\ffmpeg.exe", cmdText);
            //if (radioButton1.Checked == true)
            //{
            //    houzhui.Text = ".mp4";
            //    Command.Text = "-threads 0 -i " + "\"" + textBox_Adress.Text + "\"" + " -c copy -y -bsf:a aac_adtstoasc -movflags +faststart " + "\"" + textBox_DownloadPath.Text + "\\" + textBox_Name.Text + ".mp4" + "\"";
            //    // 启动进程执行相应命令,此例中以执行ffmpeg.exe为例  
            //    RealAction(@"Tools\ffmpeg.exe", Command.Text);
            //}
            //if (radioButton2.Checked == true)
            //{
            //    houzhui.Text = ".mkv";
            //    Command.Text = "-threads 0 -i " + "\"" + textBox_Adress.Text + "\"" + " -c copy -y -bsf:a aac_adtstoasc " + "\"" + textBox_DownloadPath.Text + "\\" + textBox_Name.Text + ".mkv" + "\"";
            //    RealAction(@"Tools\ffmpeg.exe", Command.Text);
            //}
            //if (radioButton3.Checked == true)
            //{
            //    houzhui.Text = ".ts";
            //    Command.Text = "-threads 0 -i " + "\"" + textBox_Adress.Text + "\"" + " -c copy -y -f mpegts " + "\"" + textBox_DownloadPath.Text + "\\" + textBox_Name.Text + ".ts" + "\"";
            //    RealAction(@"Tools\ffmpeg.exe", Command.Text);
            //}
            //if (radioButton4.Checked == true)
            //{
            //    houzhui.Text = ".flv";
            //    Command.Text = "-threads 0 -i " + "\"" + textBox_Adress.Text + "\"" + " -c copy -y -f f4v -bsf:a aac_adtstoasc " + "\"" + textBox_DownloadPath.Text + "\\" + textBox_Name.Text + ".flv" + "\"";
            //    RealAction(@"Tools\ffmpeg.exe", Command.Text);
            //}
        }

        private void RealAction(string StartFileName, string StartFileArg)
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = StartFileName;      // 命令  
            CmdProcess.StartInfo.Arguments = StartFileArg;      // 参数  

            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
            //CmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  

            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            CmdProcess.EnableRaisingEvents = true;                      // 启用Exited事件  
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);   // 注册进程结束事件  

            CmdProcess.Start();
            ffmpegid = CmdProcess.Id;//获取ffmpeg.exe的进程ID
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();

            // 如果打开注释，则以同步方式执行命令，此例子中用Exited事件异步执行。  
            // CmdProcess.WaitForExit();
        }

        public void Stop()
        {
            AttachConsole(ffmpegid);
            SetConsoleCtrlHandler(IntPtr.Zero, true);
            GenerateConsoleCtrlEvent(0, 0);
            FreeConsole();
        }

        //以下为实现异步输出CMD信息

        private void Init()
        {
            //3.将相应函数注册到委托事件中  
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                // 4. 异步调用，需要invoke  
                this.Invoke(ReadStdOutput, new object[] { e.Data });
            }
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(ReadErrOutput, new object[] { e.Data });
            }
        }

        private void ReadStdOutputAction(string result)
        {
            textBox_forRegex.Text = result;
            this.textBox_Info.AppendText(result + "\r\n");
        }

        private void ReadErrOutputAction(string result)
        {
            textBox_forRegex.Text = result;
            this.textBox_Info.AppendText(result + "\r\n");
        }

        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            FlashWindow(this.Handle, true);

            //设置任务栏进度条状态
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress, this.Handle);
            this.Text = "M3U8 Downloader";
            this.label_Progress.Text = "已完成：" + "100.00%";
            ProgressBar.Value = 100;
            timer1.Enabled = false;
            timer2.Enabled = false;
            label8.Text = "";
            MessageBox.Show("命令执行结束！", "M3U8 Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);  // 执行结束后触发
        }

        //格式化大小输出
        public String FormatFileSize(Double fileSize)
        {
            if (fileSize < 0)
            {
                throw new ArgumentOutOfRangeException("fileSize");
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                return string.Format("{0:########0.00} GB", ((Double)fileSize) / (1024 * 1024 * 1024));
            }
            else if (fileSize >= 1024 * 1024)
            {
                return string.Format("{0:####0.00} MB", ((Double)fileSize) / (1024 * 1024));
            }
            else if (fileSize >= 1024)
            {
                return string.Format("{0:####0.00} KB", ((Double)fileSize) / 1024);
            }
            else
            {
                return string.Format("{0} bytes", fileSize);
            }
        }
    }
}
