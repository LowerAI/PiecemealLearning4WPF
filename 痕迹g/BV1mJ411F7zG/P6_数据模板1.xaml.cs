using System.Collections.Generic;
using System.Windows;

namespace BV1mJ411F7zG
{
    /// <summary>
    /// P6_数据模板1.xaml 的交互逻辑
    /// </summary>
    public partial class P6_数据模板1 : Window
    {
        public P6_数据模板1()
        {
            InitializeComponent();
            //List<Color> ColorList = new List<Color>()
            //{
            //    new Color { Code = "#FF8C00" },
            //    new Color { Code = "#FF7F50" },
            //    new Color { Code = "#FF6EB4" },
            //    new Color { Code = "#FF4500" },
            //    new Color { Code = "#FF3030" },
            //    new Color { Code = "#FF5B45" }
            //};

            //cob.ItemsSource = ColorList;
            //lib.ItemsSource = ColorList;

            List<Test> tests = new List<Test>()
            {
                new Test { Code = "1" },
                new Test { Code = "2" },
                new Test { Code = "3" },
                new Test { Code = "4" },
                new Test { Code = "5" },
            };

            lc.ItemsSource = tests;
        }

        public class Color
        {
            public string Code { get; set; }
        }

        public class Test
        {
            public string Code { get; set; }
        }
    }
}
