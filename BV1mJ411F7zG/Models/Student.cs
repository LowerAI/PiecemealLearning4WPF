using GalaSoft.MvvmLight;

namespace BV1mJ411F7zG.Models
{
    public class Student1 : ViewModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }
    }
}