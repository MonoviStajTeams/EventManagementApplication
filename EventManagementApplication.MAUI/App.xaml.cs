using EventManagementApplication.MAUI.Models.ViewModels;
using EventManagementApplication.MAUI.Pages;

namespace EventManagementApplication.MAUI
{
    public partial class App : Application
    {
        public App(RegisterViewModel ivm)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegisterPage(ivm));
        }
    }
}