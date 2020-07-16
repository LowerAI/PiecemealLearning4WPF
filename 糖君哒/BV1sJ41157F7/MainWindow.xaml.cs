using System.Windows;
using System.Windows.Input;

namespace BV1sJ41157F7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InputBindings.Add(
                new KeyBinding(
                    FindResource("TestShortKey") as RoutedCommand,
                    new KeyGesture(Key.N, ModifierKeys.Alt)
                    )
                );
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TestTextBlock.Text = "Hello";
        }
    }
}