//using Android.App;
using LMS.Library.Models.People;
using LMS.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Maui.ViewModels.InstructorViewModels
{
    class CreatePersonViewModel
    {

        public string Name { get; set; }
        public string Classification { get; set; }

        public void CreatePerson()
        {
            StudentService.Current.Add(new Student { Name = Name, Classification = Classification });
        }
    }
}
