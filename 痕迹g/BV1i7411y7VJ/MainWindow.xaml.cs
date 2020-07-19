using MQTTnet;
using MQTTnet.Server;
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

namespace BV1i7411y7VJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMqttServer server;
        List<UserInstance> instances;
        public MainWindow()
        {
            InitializeComponent();
             instances = new List<UserInstance>();
        }

        private async void btn_Start(object sender, RoutedEventArgs e)
        {
            var optionsBuilder = new MqttServerOptionsBuilder().WithDefaultEndpoint().WithDefaultEndpointPort(1883).WithConnectionValidator(c =>
            {
                var flag = !string.IsNullOrWhiteSpace(c.Username) && !string.IsNullOrWhiteSpace(c.Password);

                if (!flag)
                {
                    c.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
                    return;
                }

                c.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.Success;
                instances.Add(new UserInstance
                {
                    clientid = c.ClientId,
                    username = c.Username,
                    password = c.Password
                });

                Showlog($"{DateTime.Now}:帐号：{c.Username}已订阅！");
            }).WithSubscriptionInterceptor(c =>
            {
                if (c == null) return;
                c.AcceptSubscription = true;
                Showlog($"{DateTime.Now}:订阅者{c.ClientId}");
            }).WithApplicationMessageInterceptor(c =>
            {
                if (c == null) return;
                c.AcceptPublish = true;
                string str = c.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(c.ApplicationMessage?.Payload);
                Showlog($"{DateTime.Now}:{str}\r\n");
            });

            server = new MqttFactory().CreateMqttServer();
            server.UseClientDisconnectedHandler(c =>
            {
                var use = instances.FirstOrDefault(t => t.clientid == c.ClientId);
                if (use != null)
                {
                    instances.Remove(use);
                    Showlog($"{DateTime.Now}:订阅者{use.username}已退出。");
                }
            });
            await server.StartAsync(optionsBuilder.Build());
        }

        private void btn_Send(object sender, RoutedEventArgs e)
        {
            instances.ForEach(arg =>
            {
                server.PublishAsync(new MqttApplicationMessage
                {
                    Topic = arg.clientid,
                    QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce,
                    Retain = false,
                    Payload = Encoding.UTF8.GetBytes("{DateTime.Now}:服务器：明天都不要来上班了！")
                });
            });
        }

        /// <summary>
        /// 更新文本框
        /// </summary>
        /// <param name="str"></param>
        private void Showlog(string str)
        {
            this.Dispatcher.Invoke(() =>
            {
                txtResult.Text += str + "\r\n";
            });
        }
    }
}
