using BV1mJ411F7zG.Models;
using System.Windows;

namespace BV1mJ411F7zG.Views
{
    /// <summary>
    /// UserView.xaml 的交互逻辑
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(Student1 stu)
        {
            InitializeComponent();
            this.DataContext = new
            {
                Model = stu
            };
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}