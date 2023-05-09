using LMS.Maui.ViewModels.InstructorViewModels;

namespace LMS.Maui.Views.InstructorViews;

public partial class ListPersonView : ContentPage
{
	public ListPersonView()
	{
		InitializeComponent();
		BindingContext = new ListPersonViewModel();
        Appearing += ListPersonView_Appearing;
	}

    private void ListPersonView_Appearing(object sender, EventArgs e)
    {
        (BindingContext as ListPersonViewModel).RefreshView();
    }
}