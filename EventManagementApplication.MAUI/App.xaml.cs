using EventManagementApplication.MAUI.Models.ViewModels;
using EventManagementApplication.MAUI.Pages;

namespace EventManagementApplication.MAUI
{
    public partial class App : Application
    {
        public App(InvitationViewModel evm)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new UserDashboard());
        }
    }
}