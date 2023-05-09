using LMS.Library.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library
{
    public class StudentService
    {
        private static StudentService? _instance;

        private StudentService() { }

        private  Person? _selectedStudent;

        public Person? SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; }
        }
        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }
                return _instance;
            }
        }


        public IEnumerable<Student?> Students
        {
            get
            {
                return Database.People.Where(p => p is Student).Select(p => p as Student);
            }
        }

        public void Add(Person student)
        {
            Database.People.Add(student);
        }

        public void Remove(Person student)
        {
            Database.People.Remove(student);
        }

    }
}
