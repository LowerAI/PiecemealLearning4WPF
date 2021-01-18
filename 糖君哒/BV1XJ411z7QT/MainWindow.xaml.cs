using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace BV1XJ411z7QT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var itemList = new ObservableCollection<ItemModel>
            {
                new ItemModel
                {
                    Icon = Encoding.UTF8.GetString(new byte[] { 0x003A }),
                    Title = "系统",
                    Text = "显示、声音、通知、电源"
                },
                new ItemModel
                {
                    Icon = Encoding.UTF8.GetString(new byte[] { 0x0022 }),
                    Title = "游戏",
                    Text = "XBox Game Bar、捕获、游戏模式"
                }
            };
            this.DataContext = itemList;
        }
    }
}
