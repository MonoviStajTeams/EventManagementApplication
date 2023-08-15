using EventManagementApplication.Entities.Dtos;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Business.Abstract;
using System.Numerics;
using Microsoft.Maui.Controls;
using EventManagementApplication.MAUI.Models.ViewModels;

namespace EventManagementApplication.MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly RegisterViewModel _rvm;
        public MainPage(RegisterViewModel rvm)
        {
            InitializeComponent();
            _rvm = rvm;
        }


        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(_rvm));
        }

        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }
        private async void ProfilePageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void MyEventPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyEvent());
        }

        private async void ForgotPasswordPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }



    }
}