using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Library.Models;

namespace LMS.Library
{
    public class CourseService
    {
        private static CourseService? _instance;

        private CourseService() { }

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        public IEnumerable<Course?> Courses
        {
            get
            {
                return Database.Courses.Where(p => p is Course).Select(p => p as Course);
            }
        }

        public void Add(Course course)
        {
            Database.Courses.Add(course);
        }

        public void Remove(Course course)
        {
            Database.Courses.Remove(course);
        }
    }
}
