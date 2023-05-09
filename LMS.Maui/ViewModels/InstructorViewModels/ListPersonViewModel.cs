using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LMS.Library;
using LMS.Library.Models.People;
//using static Android.App.DownloadManager;

namespace LMS.Maui.ViewModels.InstructorViewModels
{
    public class ListPersonViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }

        public ListPersonViewModel()
        {
            //People = new ObservableCollection<Person>(StudentService.Current.Students);
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
