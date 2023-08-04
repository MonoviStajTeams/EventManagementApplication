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
    public class InvitationApiService : GenericApiService<InvitationApiResponse>, IInvitationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;

        public InvitationApiService(string apiEndpoint) : base(apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + $"{apiEndpoint}");

        }

        public async Task<int> GetLastInvitationIdAsync()
        {
            var response = await _httpClient.GetAsync("/GetLastInvitationId");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task SendInvitationMailAsync(int invitationId)
        {
            var response = await _httpClient.GetAsync("/SendInvitationMail/{invitationId}");
            response.EnsureSuccessStatusCode();
            
        }

        public async Task<InvitationApiResponse> GetInvitationByUserId(int userId)
        {
            var response = await _httpClient.GetAsync($"/GetInvitationByUserId/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<InvitationApiResponse>();
        }
    }
}
