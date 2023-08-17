namespace EventManagementApplication.MAUI.Pages;

public partial class MyEvent : ContentPage
{
	public MyEvent()
	{
		InitializeComponent();
	}
    private async void BacktoMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}