using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace InterProcessCommunicationClient
{
    /// <summary>
    /// SendMessageReceiver.xaml 的交互逻辑
    /// 原文链接：C#中使用SendMessage在进程间传递数据的实例(https://mp.weixin.qq.com/s/MlU56EAnLuTeDJ5VJH3bWg)
    /// </summary>
    public partial class SendMessageReceiver : Window
    {
        public ObservableCollection<string> MsgList { get; set; }

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        const int WM_COPYDATA = 0x004A;

        public SendMessageReceiver()
        {
            InitializeComponent();

            MsgList = new ObservableCollection<string>();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(DefWndProc);
        }

        private IntPtr DefWndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Debug.WriteLine($"msg:{msg}");
            switch (msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = new COPYDATASTRUCT();
                    //Type t = cds.GetType();
                    //cds = (COPYDATASTRUCT)m.GetLParam(t);
                    cds = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
                    string strResult = $"{cds.dwData}:{cds.lpData}";
                    MsgList.Add(strResult);
                    break;
                default:
                    //base.DefWndProc(ref m);
                    break;
            }
            return IntPtr.Zero;
        }
    }
}
