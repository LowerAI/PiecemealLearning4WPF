using System.Windows;
using System.Windows.Controls;

namespace BV1ME411i7gC
{
    /// <summary>
    /// TipTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class TipTextBox : TextBox
    {
        public TipTextBox()
        {
            InitializeComponent();
        }

        public string TipText
        {
            get { return (string)GetValue(TipTextProperty); }
            set { SetValue(TipTextProperty, value); }
        }

        public static readonly DependencyProperty TipTextProperty = DependencyProperty.Register("TipText", typeof(string), typeof(TipTextBox), new PropertyMetadata(""));
    }
}
