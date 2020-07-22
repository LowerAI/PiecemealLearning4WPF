using System.Collections.Generic;
using System.Windows;

namespace BV115411W74L
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Student> stuList = new List<Student>
            {
                new Student { Name = "A", Result = 60 },
                new Student { Name = "B", Result = 50 },
                new Student { Name = "C", Result = 70 },
                new Student { Name = "D", Result = 80 },
                new Student { Name = "E", Result = 90 }
            };
            list.ItemsSource = stuList;
            //list.DataContext = new
            //{
            //    Model = stuList
            //};
        }
    }

    public class Student
    {
        public string Name { get; set; }

        public int Result { get; set; }
    }
}