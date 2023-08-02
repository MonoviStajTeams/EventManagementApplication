using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthApiService _authService;
        public RegisterViewModel()
        {
            _authService = new AuthApiService(apiEndpoint: "Auth");
        }

        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;

        [ObservableProperty]
        private string mail;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmpassword;



        [RelayCommand]
        private void Register()
        {
            var entity = new RegisterApiResponse
            {
                FirstName = firstname,
                LastName = lastname,
                Email = mail,
                Password = password,
            };



            _authService.Register(entity);
        }
        
    }
}
