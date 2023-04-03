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

            //App.Current.MainPage = new NavigationPage(new StudentPage());
            await Shell.Current.GoToAsync("//studentPage");

            //Console.WriteLine(sender.ToString);


            SemanticScreenReader.Announce(StudentBtn.Text);
        }
        
        private async void OnNavigate2Clicked(object sender, EventArgs e) // teacher | ta
        {

            //App.Current.MainPage = new NavigationPage(new InstructorTAPage());
            await Shell.Current.GoToAsync("//instructorTAPage");


            //Console.WriteLine(sender.ToString);


            SemanticScreenReader.Announce(InstructorTABtn.Text);
        }

        private async void OnNavigate3Clicked(object sender, EventArgs e) // admin
        {

            //App.Current.MainPage = new NavigationPage(new LMSAdminPage());
            await Shell.Current.GoToAsync("//lmsAdminPage");

            //Console.WriteLine(sender.ToString);


            SemanticScreenReader.Announce(LMSAdminBtn.Text);
        }

    }
}