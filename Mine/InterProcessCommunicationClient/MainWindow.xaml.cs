using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Interop;

namespace InterProcessCommunicationClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 通过TCP通讯获取基准板卡数据的套接字
        /// </summary>
        private Socket _socket;

        public MainWindow()
        {
            InitializeComponent();
            btnConnectToServer.Click += btnConnectToServer_Click;//事件注册
            btnSendMsg.Click += BtnSendMsg_Click;
            Closing += MainWindow_Closing;
        }

        /// <summary>
        /// 连接到Socket服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnectToServer_Click(object sender, RoutedEventArgs e)
        {
            ConnectToSocketServer();
        }

        /// <summary>
        /// 消息发送事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendMsg_Click(object sender, RoutedEventArgs e)
        {
            SendMsgBySocket(txtMsg.Text);
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            CloseSocket("客户端连接已关闭!");
        }

        /// <summary>
        /// 向文本框中追加信息
        /// </summary>
        /// <param name="str"></param>
        private void AppendTxtLogText(string str)
        {
            if (!(txtLog.Dispatcher.CheckAccess()))//判断跨线程访问
            {
                ////同步方法
                //this.Dispatcher.Invoke(new Action<string>( s => 
                //{
                //    this.txtLog.Text = string.Format("{0}\r\n{1}" , s , txtLog.Text);
                //}) ,str);
                //异步方法
                this.Dispatcher.BeginInvoke(new Action<string>(s =>
                {
                    this.txtLog.Text = string.Format("{0}\r\n{1}", s, txtLog.Text);
                }), str);
            }
            else
            {
                this.txtLog.Text = string.Format("{0}\r\n{1}", str, txtLog.Text);
            }
        }

        /// <summary>
        /// 连接按钮事件
        /// </summary>
        private void ConnectToSocketServer()
        {
            //1、创建Socket对象
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //2、连接服务器,绑定IP 与 端口
            var ipAddress = "127.0.0.1"; var port = 45000;
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            try
            {
                _socket.Connect(iPEndPoint);
            }
            catch (Exception)
            {
                AppendTxtLogText("连接失败，请重新连接!");
                return;
            }
            //3、接收消息
            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveMsgBySocket), _socket);
        }

        /// <summary>
        /// 发送socket消息
        /// </summary>
        /// <param name="msg">socket消息</param>
        private void SendMsgBySocket(string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            //6、发送消息
            _socket.Send(data, 0, data.Length, SocketFlags.None); //指定套接字的发送行为
        }

        /// <summary>
        /// 接收socket消息
        /// </summary>
        /// <param name="obj">参数Socke对象</param>
        private void ReceiveMsgBySocket(object obj)
        {
            var proxSocket = obj as Socket;
            //创建缓存内存，存储接收的信息,不能放到while中，这块内存可以循环利用
            byte[] data = new byte[1020 * 1024];
            while (true)
            {
                //if (isStopTest)
                //{
                //    return;
                //}
                int len;
                try
                {
                    //接收消息,返回字节长度
                    len = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    //7、关闭Socket
                    //异常退出
                    try
                    {
                        CloseSocket($"服务端：{proxSocket.RemoteEndPoint}非正常退出");
                    }
                    catch (Exception)
                    {
                    }
                    return;//让方法结束，终结当前客户端数据的异步线程，方法退出，即线程结束
                }

                if (len <= 0)//判断接收的字节数
                {
                    //7、关闭Socket
                    //小于0表示正常退出
                    try
                    {
                        CloseSocket($"服务端：{proxSocket.RemoteEndPoint}正常退出");
                    }
                    catch (Exception)
                    {
                    }
                    return;//让方法结束，终结当前客户端数据的异步线程，方法退出，即线程结束
                }
                //将消息显示到TxtLog
                string msg = Encoding.Default.GetString(data, 0, len);
                //拼接字符串
                AppendTxtLogText("接收到socket消息\n");
                AppendTxtLogText(msg);
            }
        }

        /// <summary>
        /// 关闭socket
        /// </summary>
        /// <param name="msg"></param>
        private void CloseSocket(string msg)
        {
            try
            {
                if (_socket.Connected)//如果是连接状态
                {
                    _socket.Shutdown(SocketShutdown.Both);//关闭连接
                    _socket.Close(100);//100秒超时间
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                AppendTxtLogText(msg);
            }
        }
    }
}
