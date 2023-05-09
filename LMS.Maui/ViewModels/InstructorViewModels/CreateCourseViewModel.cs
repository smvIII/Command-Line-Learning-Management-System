using LMS.Library;
using LMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Maui.ViewModels.InstructorViewModels
{
    class CreateCourseViewModel
    {
        public CreateCourseViewModel()
        {
            course = new Course();
        }

        public String Name { get; set; }
        public String Description { get; set; }

        public String Prefix { get; set; }

        public void CreateCourse()
        {
            CourseService.Current.Add(new Course() { Name = Name, Description = Description, Code = Prefix });
        }

        private Course course;

    }
}
