using LMS.Library;
using LMS.Library.Models.People;
using LMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace LMS.Maui.ViewModels.InstructorViewModels
{
    public class AddPersonToCourseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }

        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }

        public AddPersonToCourseViewModel() { }

        public void AddPersonToCourse()
        {
            SelectedCourse.Roster.Add(SelectedPerson);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
