using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BV1qE411M7NU
{
    public class IMultiValueDisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 3)
            {
                return null;
            }

            byte R = System.Convert.ToByte(values[0]);
            byte G = System.Convert.ToByte(values[1]);
            byte B = System.Convert.ToByte(values[2]);

            Color color = Color.FromRgb(R, G, B);
            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}