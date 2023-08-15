namespace EventManagementApplication.MAUI.Pages;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private async void BacktoMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}