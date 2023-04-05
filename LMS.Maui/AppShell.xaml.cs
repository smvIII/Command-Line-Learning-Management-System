using LMS.Maui.Pages.AdminPages;

namespace LMS.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Shell.Current.Navigating += OnShellNavigating;
        }

        private void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
        // this handles making the go back flyout item disappear when it needs to 
        {
            var currentPage = Shell.Current?.CurrentPage;
            if (currentPage.GetType() == typeof(LMSAdminPage))
            {
                LMSAdminPage.SetAdminFlyoutItemsVisibility(false);
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