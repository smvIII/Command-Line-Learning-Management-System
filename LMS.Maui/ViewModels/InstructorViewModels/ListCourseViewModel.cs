using LMS.Library.Models;
using LMS.Library.Models.People;
using LMS.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using Android.App;
//using static Android.Provider.Contacts;

namespace LMS.Maui.ViewModels.InstructorViewModels
{
    public class ListCourseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }

        private ObservableCollection<Person> _roster;
        public ObservableCollection<Person> Roster
        {
            get => _roster;
            set
            {
                if (_roster != value)
                {
                    _roster = value;
                    OnPropertyChanged(nameof(Roster));
                }
            }
        }

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse; set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    OnPropertyChanged(nameof(SelectedCourse));
                    UpdateRoster();
                }
            }
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
            //otifyPropertyChanged(nameof(People));
            //Console.WriteLine(SelectedCourse.Name);
            NotifyPropertyChanged(nameof(Courses));
            UpdateRoster();
        }

        private void UpdateRoster()
        {
            if (SelectedCourse != null)
            {
                Roster = new ObservableCollection<Person>(SelectedCourse.Roster);
            }
            else
            {
                Roster = new ObservableCollection<Person>();
            }
        }


    }
}
