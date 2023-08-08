using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Pages;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using EventManagementApplication.MAUI.Validators;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthApiService _authService;
        private readonly RegisterViewModelValidator _validator;
        public RegisterViewModel()
        {
            _authService = new AuthApiService();
            _validator = new RegisterViewModelValidator();
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

            var validationResult = _validator.Validate(this);

            if (validationResult.IsValid)
            {
                _authService.Register(entity);
            }
            else
            {
                StringBuilder errorMessageBuilder = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    errorMessageBuilder.AppendLine(error.ErrorMessage);
                }

                ErrorMessages = errorMessageBuilder.ToString();
            }
        }

        private string errorMessages;
        public string ErrorMessages
        {
            get => errorMessages;
            set => SetProperty(ref errorMessages, value);
        }
    }

}

