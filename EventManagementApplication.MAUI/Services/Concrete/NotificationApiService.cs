using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    public class NotificationApiService : GenericApiService<NotificationApiResponse>, INotificationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        public NotificationApiService(string apiEndpoint) : base(apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + $"{apiEndpoint}");
           
        }

        public async Task SendInvitationNotificationAsync(InvitationApiResponse ınvitationApiResponse, int userId)
        {
            var response = await _httpClient.GetAsync($"/SendInvitationNotification/{ınvitationApiResponse}/{userId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<UserApiResponse>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("/GetUsers");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<UserApiResponse>>();
        }


        public async Task SendReminderNotificationsAsync()
        {
            var response = await _httpClient.GetAsync("/SendReminderNotifications");
            response.EnsureSuccessStatusCode();
        }

        


    }
}
