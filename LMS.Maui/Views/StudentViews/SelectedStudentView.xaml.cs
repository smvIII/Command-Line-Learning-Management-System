using LMS.Maui.ViewModels.StudentViewModels;
namespace LMS.Maui.Views.StudentViews;


public partial class SelectedStudentView : ContentPage
{
	public SelectedStudentView()
	{
		InitializeComponent();
		BindingContext = new SelectedStudentViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as SelectedStudentViewModel).OnAppearing();
    }


}