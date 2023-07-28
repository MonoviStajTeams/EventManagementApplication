using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.Business.Abstract;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.ViewModels
{
    public partial class ForgotPasswordViewModel: ObservableObject
    {
        private readonly IAuthApiService _authService;

        public ForgotPasswordViewModel()
        {
            _authService = new AuthApiService(apiEndpoint: "auth");

        }

        [ObservableProperty]
        private string email;


        [RelayCommand]
        private async Task FetchForgotPasswordInfo()
        {
        }
        [RelayCommand]
        private async Task ForgotPasswordCommand()
        {
            var entity = new ForgotPasswordApiResponse
            {
              Email = email,
            };

            await _authService.ForgotPassword(entity).ConfigureAwait(false);
        }
    }
}
