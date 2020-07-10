using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace BV1XJ411Q7B2.ViewModel
{
    public class MetroInfo
    {
        public string Name { get; set; }

        public Brush Color { get; set; }

        public TransitionEffect Effect { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
