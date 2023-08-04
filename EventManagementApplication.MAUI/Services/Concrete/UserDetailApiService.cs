using EventManagementApplication.Entities.Concrete;
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
    public class UserDetailApiService : GenericApiService<UserDetailApiResponse>, IUserDetailApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        public UserDetailApiService(string apiEndpoint) : base(apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + $"{apiEndpoint}");
        }

        public async Task<UserDetailApiResponse> GetUserDetailByUserIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"/GetUserDetailByUserId/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDetailApiResponse>();
        }
    }
}
    