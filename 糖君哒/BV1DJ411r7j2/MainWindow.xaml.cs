using System.Windows;

namespace BV1DJ411r7j2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new NotifyBox
            { NotifyMessage = "这是弹出信息" }.Show();
        }
    }
}