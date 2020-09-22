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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BV14h411X7yt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Key[] Target = new Key[] { Key.Up, Key.Up, Key.Down, Key.Down, Key.Left, Key.Right, Key.Left, Key.Right };

        Queue<Key> KeyCache = new Queue<Key>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyCache.Enqueue(e.Key);
            if (KeyCache.Count > Target.Count())
            {
                KeyCache.Dequeue();
            }
            if (KeyCache.SequenceEqual(Target))
            {
                Background = Brushes.Pink;
            }
        }
    }
}
