using EventManagementApplication.MAUI.ViewModels.ViewModels;

namespace EventManagementApplication.MAUI;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel rvm)
	{
		InitializeComponent();
		BindingContext = rvm;
	}
}