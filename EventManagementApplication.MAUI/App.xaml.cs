using EventManagementApplication.MAUI.Models.ViewModels;
using EventManagementApplication.MAUI.Pages;

namespace EventManagementApplication.MAUI
{
    public partial class App : Application
    {
        public App(InvitationViewModel ivm)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AddInvitation(ivm));
        }
    }
}