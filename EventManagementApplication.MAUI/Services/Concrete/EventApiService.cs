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
    public class EventApiService : GenericApiService<EventApiResponse>, IEventApiService
    {
        private readonly HttpClient _httpClient;
        public EventApiService(string apiEndpoint) : base(apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + $"{apiEndpoint}");
        }


        public async Task AcceptEventAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/AcceptEvent/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task GetInactiveEventsByUserId(int userId)
        {
            var response = await _httpClient.GetAsync($"/GetInactiveEventsByUserId/{userId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task ActivateEvent(EventApiResponse eventResponse)
        {
            var response = await _httpClient.PostAsJsonAsync($"/ActivateEvent/",eventResponse);
            response.EnsureSuccessStatusCode();
        }

        public async Task GetByType(string type)
        {
            var response = await _httpClient.GetAsync($"/GetByType/{type}");
            response.EnsureSuccessStatusCode();
        }
    }
}
