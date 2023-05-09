using LMS.Maui.ViewModels.InstructorViewModels;
namespace LMS.Maui.Views.InstructorViews;

public partial class ListCourseView : ContentPage
{
	public ListCourseView()
	{
		InitializeComponent();
		BindingContext = new ListCourseViewModel();
		Appearing += ListCourseView_Appearing;
	}

    private void ListCourseView_Appearing(object sender, EventArgs e)
    {
        (BindingContext as ListCourseViewModel).RefreshView();
    }

}