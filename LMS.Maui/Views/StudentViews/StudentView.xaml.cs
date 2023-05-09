using LMS.Library;
using LMS.Maui.ViewModels;

namespace LMS.Maui.Views.StudentViews;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
		BindingContext = new StudentViewViewModel();
        Appearing += ListPersonView_Appearing;
    }

    private async void LoginClicked(object sender, EventArgs e)
    {
        StudentService.Current.SelectedStudent = (BindingContext as StudentViewViewModel).SelectedPerson;
        await Shell.Current.GoToAsync($"//selectedStudentView?");
        SemanticScreenReader.Announce(loginButton.Text);
        //StudentService.SelectedStudent = (BindingContext as StudentViewViewModel).SelectedPerson;
        //StudentService.Current.SelectedStudent = (BindingContext as StudentViewViewModel).SelectedPerson;
    }


    private void ListPersonView_Appearing(object sender, EventArgs e)
    {
        (BindingContext as StudentViewViewModel).RefreshView();
    }

}