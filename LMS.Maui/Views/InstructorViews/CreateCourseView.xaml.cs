using LMS.Maui.ViewModels.InstructorViewModels;

namespace LMS.Maui.Views.InstructorViews;

public partial class CreateCourseView : ContentPage
{
	public CreateCourseView()
	{
		InitializeComponent();
        BindingContext = new CreateCourseViewModel();
	}

    private async void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CreateCourseViewModel).CreateCourse();
        await Shell.Current.GoToAsync("//instructorTAPage");
    }

}