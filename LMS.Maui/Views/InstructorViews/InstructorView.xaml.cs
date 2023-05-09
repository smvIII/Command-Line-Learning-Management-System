namespace LMS.Maui.Views.InstructorViews;
using LMS.Maui.ViewModels;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
	}

    private async void OnNavigate1Clicked(object sender, EventArgs e) // create course FILE
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//createCourseView");
        SemanticScreenReader.Announce(createCourseBtn.Text);
    }

    private async void OnNavigate2Clicked(object sender, EventArgs e) // search course NO 
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//searchView"); 
        SemanticScreenReader.Announce(courseSearchBtn.Text);
    }

    private async void OnNavigate3Clicked(object sender, EventArgs e) // update course NO
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//updateView"); 
        SemanticScreenReader.Announce(updateCourseBtn.Text);
    }

    private async void OnNavigate4Clicked(object sender, EventArgs e) // list courses NO
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//listCourseView");
        SemanticScreenReader.Announce(listCoursesBtn.Text);
    }

    private async void OnNavigate5Clicked(object sender, EventArgs e) // add person to course NO
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//addPersonToCourseView");
        SemanticScreenReader.Announce(addPersonToCourseBtn.Text);
    }

    private async void OnNavigate6Clicked(object sender, EventArgs e) // create person FILE
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//createPersonView");
        SemanticScreenReader.Announce(createPersonBtn.Text);
    }

    private async void OnNavigate7Clicked(object sender, EventArgs e) // search person NO
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//createPersonView");
        SemanticScreenReader.Announce(createPersonBtn.Text);
    }

    private async void OnNavigate8Clicked(object sender, EventArgs e) // update person NO
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//listPersonView");
        SemanticScreenReader.Announce(createPersonBtn.Text);
    }
    private async void OnNavigate9Clicked(object sender, EventArgs e) // list person NO
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//listPersonView");
        SemanticScreenReader.Announce(createPersonBtn.Text);
    }
    private async void OnNavigate10Clicked(object sender, EventArgs e) // remove person from course
    {
        SetAdminFlyoutItemsVisibility(true);
        await Shell.Current.GoToAsync("//createPersonView");
        SemanticScreenReader.Announce(createPersonBtn.Text);
    }


    public static void SetAdminFlyoutItemsVisibility(bool isVisible) // sets goback as visible
    {
        //var adminFlyoutItem1 = Shell.Current.FindByName<FlyoutItem>("AdminFlyouItem1");
        //var adminFlyoutItem2 = Shell.Current.FindByName<FlyoutItem>("AdminFlyoutItem2");
        //adminFlyoutItem1.FlyoutItemIsVisible = isVisible;
        Shell.Current.FindByName<FlyoutItem>("AdminGoBackFlyout").FlyoutItemIsVisible = isVisible;
    }

}