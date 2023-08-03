using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _httpClient;

        public AuthApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + "/Auth");
        }

        public async Task Login(LoginApiResponse loginResponse)
        {
            var response = await _httpClient.PostAsJsonAsync("/Login", loginResponse);
            response.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterApiResponse registerResponse)
        {
            var response = await _httpClient.PostAsJsonAsync("/Register", registerResponse);
            response.EnsureSuccessStatusCode();
        }
        public async Task ForgotPassword(ForgotPasswordApiResponse forgotPasswordResponse)
        {
            var response = await _httpClient.PostAsJsonAsync("/ForgotPassword", forgotPasswordResponse);
            response.EnsureSuccessStatusCode();
        }
    }
}
