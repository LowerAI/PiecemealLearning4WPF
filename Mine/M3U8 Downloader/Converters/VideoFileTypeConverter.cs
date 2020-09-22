using M3U8_Downloader.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace M3U8_Downloader.Converters
{
    /// <summary>
    /// 视频文件类型转换器(字符串 <-> 枚举值)
    /// </summary>
    public class VideoFileTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vft = (VideoFileType)value;
            return vft == (VideoFileType)int.Parse(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int n = -1;
            if (value == null || !int.TryParse(value.ToString(), out n))
            {
                return null;
            }
            return (VideoFileType)int.Parse(parameter.ToString());
        }
    }
}
