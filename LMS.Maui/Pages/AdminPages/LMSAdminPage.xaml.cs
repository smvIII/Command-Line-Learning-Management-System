namespace LMS.Maui.Pages.AdminPages;
//namespace LMS.Maui;

public partial class LMSAdminPage : ContentPage
{
	public LMSAdminPage()
	{
		InitializeComponent();
    }

    private async void OnNavigate1Clicked(object sender, EventArgs e) // student
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//createPage");
        SemanticScreenReader.Announce(createCourseBtn.Text);
    }

    private async void OnNavigate2Clicked(object sender, EventArgs e) // student
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//searchPage");
        SemanticScreenReader.Announce(courseSearchBtn.Text);
    }

    private async void OnNavigate3Clicked(object sender, EventArgs e) // student
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//updatePage");
        SemanticScreenReader.Announce(updateCourseBtn.Text);
    }

    private async void OnNavigate4Clicked(object sender, EventArgs e) // student
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//listPage");
        SemanticScreenReader.Announce(listCoursesBtn.Text);
    }

    private async void OnNavigate5Clicked(object sender, EventArgs e) // student
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//addRemovePage");
        SemanticScreenReader.Announce(addPersonToCourseBtn.Text);
    }
    public static void SetAdminFlyoutItemsVisibility(bool isVisible) // sets goback as visible
    {
        //var adminFlyoutItem1 = Shell.Current.FindByName<FlyoutItem>("AdminFlyouItem1");
        //var adminFlyoutItem2 = Shell.Current.FindByName<FlyoutItem>("AdminFlyoutItem2");
        //adminFlyoutItem1.FlyoutItemIsVisible = isVisible;
        Shell.Current.FindByName<FlyoutItem>("AdminGoBackFlyout").FlyoutItemIsVisible = isVisible;
    }

}