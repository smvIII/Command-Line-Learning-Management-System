//using LMS.Maui.Pages.AdminPages;
using LMS.Maui.Views.InstructorViews;
using LMS.Maui.Views.StudentViews;

namespace LMS.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute("listPage", typeof(ListPage));
            //Shell.Current.Navigating += OnShellNavigating;
        }

        private void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
        // this handles making the go back flyout item disappear when it needs to 
        {
            var currentPage = Shell.Current?.CurrentPage;
            if (currentPage.GetType() == typeof(InstructorView) || currentPage.GetType() == typeof(StudentView))
            {
                InstructorView.SetAdminFlyoutItemsVisibility(false);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Navigated += OnShellNavigated;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Navigated -= OnShellNavigated;
        }

    }
}