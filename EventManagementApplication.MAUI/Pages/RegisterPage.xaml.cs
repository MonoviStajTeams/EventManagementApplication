using EventManagementApplication.MAUI.Models.ViewModels;
using EventManagementApplication.MAUI.Pages;
using System.Windows.Input;

namespace EventManagementApplication.MAUI;

public partial class RegisterPage : ContentPage
{
    private readonly LoginViewModel _lvm;
    public RegisterPage(RegisterViewModel rvm)
	{
		InitializeComponent();
		BindingContext = rvm;
        _lvm = new LoginViewModel();
	}

    private async void NavigateToLoginPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage(_lvm));
    }

}