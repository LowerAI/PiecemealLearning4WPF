using BV1mJ411F7zG.Db;
using BV1mJ411F7zG.Models;
using BV1mJ411F7zG.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BV1mJ411F7zG.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            localDb = new LocalDb();
            QueryCommand = new RelayCommand(Query);
            ResetCommand = new RelayCommand(Reset);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand<int>(Id => Edit(Id));
            DeleteCommand = new RelayCommand<int>(Id => Delete(Id));
        }

        private LocalDb localDb;

        private string search = string.Empty;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        public RelayCommand QueryCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DeleteCommand { get; set; }

        private ObservableCollection<Student1> gridModelList;

        public ObservableCollection<Student1> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value; RaisePropertyChanged(); }
        }

        public void Query()
        {
            var models = localDb.GetStudentsByName(search);
            GridModelList = new ObservableCollection<Student1>();
            if (models != null)
            {
                models.ForEach(arg =>
                {
                    GridModelList.Add(arg);
                });
            }
        }

        public void Add()
        {
            Student1 student = new Student1();
            UserView view = new UserView(student);
            var r = view.ShowDialog();
            if (r.Value)
            {
                student.Id = GridModelList.Max(t => t.Id + 1);
                localDb.AddStudent(student);
                Query();
            }
        }

        public void Reset()
        {
            Search = string.Empty;
            Query();
            //GridModelList.Clear();
            //var models = localDb.GetStudents();
            //if (models != null)
            //{
            //    models.ForEach(arg =>
            //    {
            //        GridModelList.Add(arg);
            //    });
            //}
        }

        public void Edit(int id)
        {
            var model = localDb.GetStudentById(id);
            if (model != null)
            {
                UserView view = new UserView(model);
                var r = view.ShowDialog();
                if (r.Value)
                {
                    var newModel = GridModelList.FirstOrDefault(t => t.Id == model.Id);
                    if (newModel != null)
                    {
                        newModel.Name = model.Name;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            var model = localDb.GetStudentById(id);
            if (model != null)
            {
                var r = MessageBox.Show($"确认删除当前用户：{model.Name}?", "操作提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (r == MessageBoxResult.OK)
                {
                    localDb.DelStudent(model.Id);
                    Query();
                }
            }
        }
    }
}