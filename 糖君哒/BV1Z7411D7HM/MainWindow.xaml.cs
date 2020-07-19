using System.Windows;
using System.Windows.Controls;

namespace BV1Z7411D7HM
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var rdbtn = sender as RadioButton;
            VisualStateManager.GoToElementState(bd, rdbtn.Content.ToString(), true);
        }
    }
}