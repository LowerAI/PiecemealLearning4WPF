using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV1mJ411F7zG
{
    public class MainViewModel1 : ViewModelBase
    {
        public MainViewModel1()
        {
            Name = "Hello";
            SaveCommand = new RelayCommand(() =>
            {
                Name = "No";
            });
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(); // 触发数据同步
            }
        }

        public RelayCommand SaveCommand { get; private set; }
    }
}
