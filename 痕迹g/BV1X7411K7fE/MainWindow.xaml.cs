using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BV1X7411K7fE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model model;

        public MainWindow()
        {
            InitializeComponent();

            //Binding bind = new Binding("Text");
            //bind.Source = txt1;
            //bind.Mode = BindingMode.TwoWay;
            //txt2.SetBinding(TextBox.TextProperty, bind);

            model = new Model();
            //bind.Source = model;
            //BindingOperations.SetBinding(txt1, TextBox.TextProperty, bind);
            //txt1.SetBinding(TextBox.TextProperty, bind);
            //txt2.SetBinding(TextBox.TextProperty, bind);

            Binding bind = new Binding("Text") { Source = txt1 };
            BindingOperations.SetBinding(model, Model.TextProperty, bind);
            txt2.SetBinding(TextBox.TextProperty, bind);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(model.Text);
        }
    }

    public class Model : DependencyObject
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty TextProperty =
        //    DependencyProperty.Register("Text", typeof(string), typeof(Model), new PropertyMetadata("Demo"), new ValidateValueCallback(ValidateValue));
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Model), new FrameworkPropertyMetadata(new PropertyChangedCallback(CallBack)));

        private static bool ValidateValue(object value)
        {
            return true;
        }

        private static void CallBack(DependencyObject obj, DependencyPropertyChangedEventArgs arg)
        {
            Console.WriteLine("我发生了变化");
        }
    }
}