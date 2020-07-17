using System;
using System.Globalization;
using System.Windows.Data;

namespace BV1qE411M7NU
{
    public class IDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string str = value.ToString();
                if (str == "0")
                {
                    return "YES";
                }
                return "NO";
            }
            return "NO";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}