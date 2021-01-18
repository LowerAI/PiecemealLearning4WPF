using BV1uJ411n7Zw.Entity;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace BV1uJ411n7Zw.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            InitUserModuleBar();
        }

        public ObservableCollection<UserModule> UserModules { get; set; }

        public void InitUserModuleBar()
        {
            UserModules = new ObservableCollection<UserModule>
            {
                new UserModule
                {
                    FilePath = "images/image1.jpg",
                    UserName = "张三",
                    Content = "What's up",
                    SignTime = "32分钟前"
                },
                new UserModule
                {
                    FilePath = "images/image2.jpg",
                    UserName = "李四",
                    Content = "Nice one",
                    SignTime = "2天前"
                },
                new UserModule
                {
                    FilePath = "images/image3.jpg",
                    UserName = "王五",
                    Content = "Go on in comi",
                    SignTime = "1周前"
                },
                new UserModule
                {
                    FilePath = "images/image4.jpg",
                    UserName = "赵六",
                    Content = "I'm coming",
                    SignTime = "2周前"
                },
                new UserModule
                {
                    FilePath = "images/image5.jpg",
                    UserName = "陈七",
                    Content = "Oh My God!",
                    SignTime = "3天前"
                },
                new UserModule
                {
                    FilePath = "images/image6.jpg",
                    UserName = "刘八",
                    Content = "I'm happy",
                    SignTime = "7天前"
                },
                new UserModule
                {
                    FilePath = "images/image7.jpg",
                    UserName = "李九",
                    Content = "Shit",
                    SignTime = "1分钟前"
                },
                new UserModule
                {
                    FilePath = "images/image8.jpg",
                    UserName = "杨一",
                    Content = "Ok",
                    SignTime = "9天前"
                }
            };
        }
    }
}
