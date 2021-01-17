using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace BV1HJ411w7eN.Models
{
    public class MenuModel : ViewModelBase
    {
        /// <summary>
        /// 图标颜色值
        /// </summary>
        public string IconFont { get; set; }

        public string Title { get; set; }

        public string BackColor { get; set; }

        /// <summary>
        /// 是否显示图标
        /// </summary>
        public bool Display { get; set; } = true;

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }

    }

    public class TaskInfo
    {
        public string Content { get; set; }
    }
}
