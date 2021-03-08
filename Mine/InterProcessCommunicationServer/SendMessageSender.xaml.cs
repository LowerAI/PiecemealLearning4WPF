using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace InterProcessCommunicationServer
{
    /// <summary>
    /// SendMessageSender.xaml 的交互逻辑
    /// 原文链接：C#中使用SendMessage在进程间传递数据的实例(https://mp.weixin.qq.com/s/MlU56EAnLuTeDJ5VJH3bWg)
    /// </summary>
    public partial class SendMessageSender : Window
    {
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        //Win32 API函数
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        const int WM_COPYDATA = 0x004A;

        public SendMessageSender()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            int hWnd = FindWindow(null, @"SendMessageReceiver");
            if (hWnd == 0)
            {
                MessageBox.Show("555，未找到消息接受者！");
            }
            else
            {
                byte[] sarr = Encoding.Default.GetBytes(txtString.Text);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)Convert.ToInt16(txtInt.Text);//可以是任意值
                cds.cbData = len + 1;//指定lpData内存区域的字节数
                cds.lpData = txtString.Text;//发送给目标窗口所在进程的数据
                SendMessage(hWnd, WM_COPYDATA, 0, ref cds);
            }
        }
    }
}
