using System.Windows;

namespace BV11J411S7Zf
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
            new MessageWindow
            {
                Owner = this,
                Message = "你好，糖君"
            }.ShowDialog();
        }
    }
}