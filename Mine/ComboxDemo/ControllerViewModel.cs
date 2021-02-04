using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace ComboxDemo
{
    // 2021-01-27:WPF 枚举类型与ComboBox绑定_YouyoMei的博客-CSDN博客 https://blog.csdn.net/youyomei/article/details/105300089
    // 2021-01-27:WPF ComboBox 绑定选择事件_天明Future-CSDN博客 https://blog.csdn.net/time2017/article/details/106337219
    // 2021-01-27:WPF中comboBox组件如何绑定里面有Description的枚举_LYQ的博客-CSDN博客 https://blog.csdn.net/qq_31298129/article/details/53404983

    /// <summary>
    /// 
    /// </summary>
    public class ControllerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand SelectItemChangedCommand { get; set; }

        public ControllerViewModel()
        {
            SelectItemChangedCommand = new ActionCommand(NotifySelectedItemChanged);
            var source = new Dictionary<int, string>();

            foreach (var item in Enum.GetValues(typeof(AzimuthMapType)))
            {
                source.Add((int)(AzimuthMapType)Enum.Parse(typeof(AzimuthMapType), item.ToString()), item.ToString());
            }
            AzimuthMapTypeSources = source;
        }

        public IEnumerable<KeyValuePair<int, string>> AzimuthMapTypeSources
        {
            get;
            private set;
        }

        public int selectedAmtIndex;

        public int SelectedAmtIndex
        {
            get { return selectedAmtIndex; }
            set
            {
                selectedAmtIndex = value;
                OnPropertyChanged();
            }
        }

        public void NotifySelectedItemChanged()
        {
            var val = SelectedAmtIndex;
            Trace.WriteLine($"选定值：{val}");
        }

        public Dictionary<Gender, string> Genders
        {
            get
            {
                var r = new Dictionary<Gender, string>();
                //foreach (var item in Enum.GetValues(typeof(Gender)))
                //{
                //    r.Add(item, item.GetDescription());
                //}
                return r;
            }
        }

        /// <summary>
        /// 根据值得到中文备注
        /// </summary>
        /// <param name="e"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        //public static string GetDescription(this object value)
        //{
        //    if (value == null)
        //        return string.Empty;

        //    Type type = value.GetType();
        //    var fieldInfo = type.GetField(Enum.GetName(type, value));
        //    if (fieldInfo != null)
        //    {
        //        if (Attribute.IsDefined(fieldInfo, typeof(DescriptionAttribute)))
        //        {
        //            var description =
        //                Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        //            if (description != null)
        //                return description.Description;
        //        }
        //    }
        //    return string.Empty;
        //}
    }
}
