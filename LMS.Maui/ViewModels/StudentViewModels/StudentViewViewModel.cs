using LMS.Library;
using LMS.Library.Models.People;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Maui.ViewModels
{
    public class StudentViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Person SelectedPerson { get; set; }
        public StudentViewViewModel() { }
        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
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
            NotifyPropertyChanged(nameof(People));
            //NotifyPropertyChanged(nameof(Courses));
        }

    }
}
