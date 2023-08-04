using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthApiService _authApiService;

        public LoginViewModel()
        {
            _authApiService = new AuthApiService();
        }

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;


        [RelayCommand]
        private async Task FetchLoginInfo()
        {

        }
        [RelayCommand]
        private async Task LoginUser()
        {
            var entity = new LoginApiResponse
            {
                Email = email,
                Password = password
            };

            await _authApiService.Login(entity).ConfigureAwait(false);
        }

    }
}
