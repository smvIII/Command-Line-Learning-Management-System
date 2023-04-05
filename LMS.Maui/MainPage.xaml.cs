//using Android.OS;
using LMS.Maui.Pages;

namespace LMS.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
        }
        

        private async void OnNavigate1Clicked(object sender, EventArgs e) // student
        {
            //SetAdminFlyoutItemsVisibility(false);
            await Shell.Current.GoToAsync("//studentPage");
            SemanticScreenReader.Announce(StudentBtn.Text);
        }
        
        private async void OnNavigate2Clicked(object sender, EventArgs e) // teacher | ta
        {
            //SetAdminFlyoutItemsVisibility(false);
            await Shell.Current.GoToAsync("//instructorTAPage");
            SemanticScreenReader.Announce(InstructorTABtn.Text);
        }

        private async void OnNavigate3Clicked(object sender, EventArgs e) // admin
        {
            //SetAdminFlyoutItemsVisibility(true);
            await Shell.Current.GoToAsync("//lmsAdminPage");
            SemanticScreenReader.Announce(LMSAdminBtn.Text);
        }
        /*public static void SetAdminFlyoutItemsVisibility(bool isVisible) // sets goback as visible
        {
            var adminFlyoutItem1 = Shell.Current.FindByName<FlyoutItem>("AdminFlyoutItem1");
            var adminFlyoutItem2 = Shell.Current.FindByName<FlyoutItem>("AdminFlyoutItem2");
            adminFlyoutItem1.FlyoutItemIsVisible = isVisible;
            adminFlyoutItem2.FlyoutItemIsVisible = isVisible;
        } */
    }
}