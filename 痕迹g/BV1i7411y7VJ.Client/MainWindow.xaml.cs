﻿using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
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

namespace BV1i7411y7VJ.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMqttClient client;
        string clientId = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_Start(object sender, RoutedEventArgs e)
        {
            clientId = Guid.NewGuid().ToString();
            var options = new MqttClientOptionsBuilder().WithTcpServer("127.0.0.1", 1883).WithClientId(clientId).WithCredentials("admin", "123").Build();

            client = new MqttFactory().CreateMqttClient();
            client.UseConnectedHandler(async c =>
            {
                // 订阅服务端消息
                await client.SubscribeAsync(new TopicFilterBuilder().WithTopic(clientId).Build());
            }).UseDisconnectedHandler(c =>
            {
                Showlog(c.Exception.Message);
            }).UseApplicationMessageReceivedHandler(c =>
            {
                string str = Encoding.UTF8.GetString(c.ApplicationMessage.Payload);
                Showlog(str);
            });

            await client.ConnectAsync(options);
        }

        private void btn_Send(object sender, RoutedEventArgs e)
        {
            var msg = new MqttApplicationMessageBuilder().WithTopic(clientId).WithPayload($"{DateTime.Now}:你好").WithExactlyOnceQoS().WithRetainFlag().Build();
            client.PublishAsync(msg);
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
