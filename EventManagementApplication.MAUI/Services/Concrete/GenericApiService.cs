using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    public class GenericApiService<T> : IGenericApiService<T>
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;

        public GenericApiService(string apiEndpoint)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
            _apiEndpoint = apiEndpoint;
        }

        public async Task<T> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var _httpClients = new HttpClient();
            var response = await _httpClients.GetAsync("https://10.0.2.2:7080/api/Event/EventList");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
        }

        public async Task Create(T entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiEndpoint, entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(T entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_apiEndpoint}/{GetId(entity)}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }

      
        private int GetId(T entity)
        {
            
            throw new NotImplementedException();
        }
    }
}
