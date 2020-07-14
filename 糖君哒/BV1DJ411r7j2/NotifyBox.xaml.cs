using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BV1DJ411r7j2
{
    /// <summary>
    /// NotifyBox.xaml 的交互逻辑
    /// </summary>
    public partial class NotifyBox : Window
    {
        public NotifyBox()
        {
            InitializeComponent();
            Left = SystemParameters.WorkArea.Width - Width;
            Top = SystemParameters.WorkArea.Height - Height;
        }

        public string NotifyMessage { get; set; }

        private async void OpenStoryboard_Completed(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            BeginStoryboard(FindResource("CloseStoryboard") as Storyboard);
        }

        private void CloseStoryboard_Completed(object sender, EventArgs e)
        {
            Close();
        }

        private void ThisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tbk_Message.Text = NotifyMessage;
        }
    }
}