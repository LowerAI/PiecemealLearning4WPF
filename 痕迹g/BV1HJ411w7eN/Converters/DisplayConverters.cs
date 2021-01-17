﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BV1HJ411w7eN.Converters
{
    public class DisplayConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (bool.TryParse(value.ToString(), out bool result))
                {
                    if (result)
                    {
                        return Visibility.Visible;
                    }
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
