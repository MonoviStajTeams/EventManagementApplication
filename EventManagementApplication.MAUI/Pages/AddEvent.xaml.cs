using EventManagementApplication.MAUI.Models.ViewModels;

namespace EventManagementApplication.MAUI.Pages;

public partial class AddEvent : ContentPage
{
	public AddEvent(EventViewModel evm)
	{
		InitializeComponent();
		BindingContext = evm;
	}
}