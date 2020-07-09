using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV1mJ411F7zG
{
    public class MainViewModel2 : INotifyPropertyChanged
    {
        public MainViewModel2()
        {
            Name = "Hello";
            Task.Run(async () =>
            {
                await Task.Delay(3000);
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
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string properName)
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(properName));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properName));
        }
    }
}
