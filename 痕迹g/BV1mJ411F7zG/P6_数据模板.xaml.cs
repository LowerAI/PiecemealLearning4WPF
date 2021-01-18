using System.Collections.Generic;
using System.Windows;

namespace BV1mJ411F7zG
{
    /// <summary>
    /// P6_数据模板.xaml 的交互逻辑
    /// </summary>
    public partial class P6_数据模板 : Window
    {
        public P6_数据模板()
        {
            InitializeComponent();

            List<Student> students = new List<Student>()
            {
                new Student { UserName = "小王", ClassName = "高二三班", Address = "广州市" },
                new Student { UserName = "小李", ClassName = "高二六班", Address = "清远市" },
                new Student { UserName = "小张", ClassName = "高一一班", Address = "深圳市" },
                new Student { UserName = "小黑", ClassName = "高一三班", Address = "赣州市" }
            };
            gd.ItemsSource = students;
        }
    }

    public class Student
    {
        public string UserName { get; set; }
        public string ClassName { get; set; }
        public string Address { get; set; }
    }
}
