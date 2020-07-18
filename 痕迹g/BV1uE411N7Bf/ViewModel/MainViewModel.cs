using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;

namespace BV1uE411N7Bf.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Modules = new List<Module>
            {
                new Module { Name = "Module1" },
                new Module { Name = "Module2" },
                new Module { Name = "Module3" }
            };

            OpenCommand = new RelayCommand<string>(t => OpenPage(t));

            Module = new Module { Name = "单个模块" };
        }

        public List<Module> Modules { get; private set; }

        public RelayCommand<string> OpenCommand { get; private set; }

        private object page;

        public object Page
        {
            get { return page; }
            set { page = value; RaisePropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private Module module;

        public Module Module
        {
            get { return module; }
            set { module = value; }
        }

        public void OpenPage(string name)
        {
            Messenger.Default.Send(name, "GetData");
            //this.Name = name;
            //switch (name)
            //{
            //    case "Module1":
            //        Page = new Page1();
            //        break;

            //    case "Module2":
            //        Page = new Page2();
            //        break;

            //    case "Module3":
            //        Page = new Page3();
            //        break;
            //}
        }
    }
}