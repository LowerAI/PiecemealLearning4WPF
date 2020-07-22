using System.Windows;
using System.Windows.Controls;

namespace BV115411W74L
{
    public class TestDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HighTemplate { get; set; }

        public DataTemplate LowTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var stu = (Student)item;
            if (stu.Result >= 80)
            {
                return HighTemplate;
            }
            else
            {
                return LowTemplate;
            }
        }
    }
}