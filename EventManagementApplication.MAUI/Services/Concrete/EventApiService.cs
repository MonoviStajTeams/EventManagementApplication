﻿using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    public class EventApiService : GenericApiService<EventApiResponse>, IEventApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        public EventApiService(string apiEndpoint) : base(apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
            _apiEndpoint = apiEndpoint;
        }


        public async Task AcceptEventAsync(int id)
        {
            var response = await _httpClient.GetAsync($"UserInvitation/AcceptEvent/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
