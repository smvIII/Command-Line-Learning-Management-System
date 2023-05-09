using LMS.Maui.ViewModels.InstructorViewModels;
namespace LMS.Maui.Views.InstructorViews;

public partial class AddPersonToCourseView : ContentPage
{
	public AddPersonToCourseView()
	{
		InitializeComponent();
		BindingContext = new AddPersonToCourseViewModel();
        Appearing += AddPersonToCourseView_Appearing;
    }
    private async void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as AddPersonToCourseViewModel).AddPersonToCourse();
        await Shell.Current.GoToAsync("//instructorTAPage");
    }

    private void AddPersonToCourseView_Appearing(object sender, EventArgs e)
    {
        (BindingContext as AddPersonToCourseViewModel).RefreshView();
    }
}