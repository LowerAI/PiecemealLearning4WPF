using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows;

namespace SignalRDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .Build();

            connection.On<string>("online", (msg) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    txtInfo.Text += msg + "\r\n";
                });
            });

            connection.On<string, string>("ReceiveMessage", (user, msg) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    txtMsg.Text += $"{user}:{msg} \r\n";
                });
            });

            connection.StartAsync();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            string title = $"监工{new Random().Next(1, 99999)}号";
            Title = title;
            connection.InvokeAsync("Login", title);
            btnSend.IsEnabled = true;
        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            connection.InvokeAsync("SignOut", Title);
            connection.StopAsync();
            this.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            connection.InvokeAsync("SendMessage", Title, txtSend.Text);
        }
    }
}
