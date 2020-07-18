using BV1uE411N7Bf.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace BV1uE411N7Bf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, "GetData", GetData);
            this.DataContext = new MainViewModel();
        }

        private void GetData(string name)
        {
            MessageBox.Show(name);
        }
    }
}