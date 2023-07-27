using EventManagementApplication.Entities.Dtos;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Business.Abstract;
using System.Numerics;
using Microsoft.Maui.Controls;

namespace EventManagementApplication.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IAuthService _authService;

        public MainPage(IAuthService authService)
        {
            _authService = authService;
        }
        public MainPage()
        {
            InitializeComponent();
        }


        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

    }
}