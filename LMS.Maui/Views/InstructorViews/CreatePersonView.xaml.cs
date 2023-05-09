namespace LMS.Maui.Views.InstructorViews;
using LMS.Maui.ViewModels.InstructorViewModels;
public partial class CreatePersonView : ContentPage
{
	public CreatePersonView()
	{
		InitializeComponent();
		BindingContext = new CreatePersonViewModel();
	}

    private async void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CreatePersonViewModel).CreatePerson();
		await Shell.Current.GoToAsync("//instructorTAPage");
    }

}