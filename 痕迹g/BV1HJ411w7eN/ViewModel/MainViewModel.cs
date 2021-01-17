using BV1HJ411w7eN.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace BV1HJ411w7eN.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            MenuModels.Add(new MenuModel { IconFont = "\xe7ed", Title = "我的一天", BackColor = "#218868", Display = false });
            MenuModels.Add(new MenuModel { IconFont = "\xe614", Title = "重要", BackColor = "#EE3B3B" });
            MenuModels.Add(new MenuModel { IconFont = "\xe72a", Title = "已计划日程", BackColor = "#218868" });
            MenuModels.Add(new MenuModel { IconFont = "\xe64e", Title = "已分配给我", BackColor = "#EE3B3B" });
            MenuModels.Add(new MenuModel { IconFont = "\xe6d3", Title = "任务", BackColor = "#218868" });

            SelectedCommand = new RelayCommand<MenuModel>(t => Select(t));
            SelectedTaskCommand = new RelayCommand<TaskInfo>(t => SelectedTask(t));

            MenuModel = MenuModels[0];
        }

        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); }
        }

        private MenuModel menuModel;

        public MenuModel MenuModel
        {
            get { return menuModel; }
            set { menuModel = value; RaisePropertyChanged(); }
        }

        private TaskInfo info;

        public TaskInfo Info
        {
            get { return info; }
            set { info = value; RaisePropertyChanged(); }
        }


        public RelayCommand<MenuModel> SelectedCommand { get; set; }
        public RelayCommand<TaskInfo> SelectedTaskCommand { get; set; }

        private void Select(MenuModel model)
        {
            MenuModel = model;
        }

        public void AddTaskInfo(string content)
        {
            MenuModel.TaskInfos.Add(new TaskInfo
            {
                Content = content
            });
        }

        public void SelectedTask(TaskInfo task)
        {
            Info = task;
            Messenger.Default.Send(task, "Expand");
        }
    }
}
