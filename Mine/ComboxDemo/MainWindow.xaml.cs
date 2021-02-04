using System.Windows;

namespace ComboxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ControllerViewModel();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
