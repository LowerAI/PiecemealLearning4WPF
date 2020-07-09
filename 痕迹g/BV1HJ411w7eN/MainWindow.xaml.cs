using BV1HJ411w7eN.Models;
using BV1HJ411w7eN.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BV1HJ411w7eN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseDown += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            Messenger.Default.Register<TaskInfo>(this, "Expand", ExpandColumn);
            this.DataContext = new MainViewModel();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string inputValue = InputText.Text;
                if (string.IsNullOrWhiteSpace(inputValue))
                {
                    return;
                }

                var vm = this.DataContext as MainViewModel;
                vm.AddTaskInfo(inputValue);
                InputText.Text = string.Empty;
            }
        }

        private void ExpandColumn(TaskInfo task)
        {
            var cdf = grc.ColumnDefinitions;
            if (cdf[1].Width == new GridLength(0))
            {
                cdf[1].Width = new GridLength(280);

                btnmin.Foreground = new SolidColorBrush(Colors.Black);
                btnmax.Foreground = new SolidColorBrush(Colors.Black);
                btnclose.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                cdf[1].Width = new GridLength(0);

                btnmin.Foreground = new SolidColorBrush(Colors.White);
                btnmax.Foreground = new SolidColorBrush(Colors.White);
                btnclose.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.Source as Button;
            switch (btn.Name)
            {
                case "btnmin":
                    this.WindowState = WindowState.Minimized;
                    break;

                case "btnmax":
                    this.WindowState = WindowState.Maximized;
                    break;

                case "btnclose":
                    this.Close();
                    break;
            }
        }
    }
}
