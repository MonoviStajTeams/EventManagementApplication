using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Abstract
{
    public interface IAuthApiService 
    {
        Task Login(LoginApiResponse loginResponse);
        Task Register(RegisterApiResponse registerResponse);
        Task ForgotPassword(ForgotPasswordApiResponse forgotPasswordResponse);
           
    }
}
