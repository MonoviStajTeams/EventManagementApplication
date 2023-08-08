using EventManagementApplication.MAUI.Models.ViewModels;
using EventManagementApplication.MAUI.Pages;
using System.Windows.Input;

namespace EventManagementApplication.MAUI;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel rvm)
	{
		InitializeComponent();
		BindingContext = rvm;
        
	}

    private async void NavigateToLoginPage(object sender, EventArgs e)
    {
        return;
    }

}