using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BV1mJ411F7zG
{
    /// <summary>
    /// P7_数据绑定1.xaml 的交互逻辑
    /// </summary>
    public partial class P7_数据绑定1 : Window
    {
        public P7_数据绑定1()
        {
            InitializeComponent();
            //this.DataContext = new MainViewModel();
            this.DataContext = new MainViewModel1();

            //txt.DataContext = new Person() { };
        }
    }

    public class Person
    {
        public string Name { get; set; } = "ABC";
    }
}
