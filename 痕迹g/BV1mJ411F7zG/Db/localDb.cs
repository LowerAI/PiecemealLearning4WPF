using BV1mJ411F7zG.Models;
using System.Collections.Generic;
using System.Linq;

namespace BV1mJ411F7zG.Db
{
    public class LocalDb
    {
        public LocalDb()
        {
            init();
        }

        private List<Student1> Student1s;

        private void init()
        {
            Student1s = new List<Student1>();
            for (int i = 0; i < 30; i++)
            {
                Student1s.Add(new Student1 { Id = i, Name = $"Sample{i}" });
            }
        }

        public List<Student1> GetStudents()
        {
            return Student1s;
        }

        public void AddStudent(Student1 stu)
        {
            Student1s.Add(stu);
        }

        public void DelStudent(int id)
        {
            var model = Student1s.FirstOrDefault(testc => testc.Id == id);
            if (model != null)
            {
                Student1s.Remove(model);
            }
        }

        public List<Student1> GetStudentsByName(string name)
        {
            return Student1s.Where(q => q.Name.Contains(name)).ToList();
        }

        public Student1 GetStudentById(int id)
        {
            var model = Student1s.FirstOrDefault(testc => testc.Id == id);
            if (model != null)
            {
                return new Student1
                {
                    Id = model.Id,
                    Name = model.Name
                };
            }
            return null;
        }
    }
}