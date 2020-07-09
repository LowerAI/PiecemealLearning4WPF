using BV1mJ411F7zG.ViewModel;
using System.Windows;

namespace BV1mJ411F7zG
{
    /// <summary>
    /// P8_MVVM模式.xaml 的交互逻辑
    /// </summary>
    public partial class P8_MVVM模式 : Window
    {
        public P8_MVVM模式()
        {
            InitializeComponent();

            MainViewModel viewModel = new MainViewModel();
            viewModel.Query();

            this.DataContext = viewModel;
        }
    }
}