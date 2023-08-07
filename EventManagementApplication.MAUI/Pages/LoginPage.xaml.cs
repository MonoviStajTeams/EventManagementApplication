using EventManagementApplication.MAUI.Models.ViewModels;

namespace EventManagementApplication.MAUI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel lvm)
	{
		InitializeComponent();
        BindingContext = lvm;
    }


    //private void NavigateToRegisterPage()
    //{
    //    // Navigate to the LoginPage page.
    //    Navigation.PushAsync(new RegisterPage());
    //}
}