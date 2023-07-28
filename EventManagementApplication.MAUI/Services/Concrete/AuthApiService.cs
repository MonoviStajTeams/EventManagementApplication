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
        private readonly string _apiEndpoint;

        public AuthApiService(string apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
            _apiEndpoint = apiEndpoint;
        }

        public async Task Login(LoginApiResponse loginResponse)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiEndpoint, loginResponse);
            response.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterApiResponse registerResponse)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiEndpoint, registerResponse);
            response.EnsureSuccessStatusCode();
        }
    }
}
