using EventManagementApplication.MAUI.Models.ViewModels;

namespace EventManagementApplication.MAUI
{
    public partial class App : Application
    {
        public App(RegisterViewModel rvm)
        {
            InitializeComponent();

            MainPage = new RegisterPage(rvm);
        }
    }
}