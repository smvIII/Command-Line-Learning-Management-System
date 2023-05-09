using LMS.Library;
using LMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Maui.ViewModels.StudentViewModels
{
    public class SelectedStudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string SelectedPersonName => StudentService.Current.SelectedStudent.Name;

        private ObservableCollection<Course> _enrolledCourses;
        public ObservableCollection<Course> EnrolledCourses
        {
            get => _enrolledCourses;
            set
            {
                _enrolledCourses = value;
                OnPropertyChanged(nameof(EnrolledCourses));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnAppearing()
        {
            //OnPropertyChanged(nameof(SelectedPersonName));
            var selectedStudent = StudentService.Current.SelectedStudent;

            // Get all the courses from the database
            var allCourses = Database.Courses;

            // Initialize the enrolled courses list
            EnrolledCourses = new ObservableCollection<Course>();

            // Loop through each course and add it to the enrolled courses list
            foreach (var course in allCourses)
            {
                if (course.Roster.Contains(selectedStudent))
                {
                    EnrolledCourses.Add(course);
                }
            }

            OnPropertyChanged(nameof(SelectedPersonName));

        }
    }
}
