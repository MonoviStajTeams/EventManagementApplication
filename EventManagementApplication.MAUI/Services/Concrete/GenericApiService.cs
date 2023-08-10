using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    public class GenericApiService<T> : IGenericApiService<T>
    {
        private readonly string _apiEndPoint;

        public GenericApiService(string apiEndpoint)
        {
            _apiEndPoint = apiEndpoint;
            //_httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + $"{apiEndpoint}");
        }

        public async Task<T> GetById(int id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://bytesynthix.com/api/{_apiEndPoint}/GetById/{id}");
            var response = await httpClient.GetAsync(httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri($"https://bytesynthix.com/api/{_apiEndPoint}/GetAll");
                var response = await httpClient.GetAsync(httpClient.BaseAddress);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
                }
                else
                {
                    // API'den başarısız yanıt alındı.
                    throw new Exception("API'den başarısız yanıt alındı.");
                }
            }
            catch (HttpRequestException ex)
            {
                // API'ye bağlanma hatası
                throw new Exception("API ile bağlantı hatası oluştu.", ex);
            }
            catch (Exception ex)
            {
                // Diğer olası hatalar
                throw new Exception("API isteği başarısız.", ex);
            }
        }


        public async Task Create(T entity)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://bytesynthix.com/api/{_apiEndPoint}/Create");
            var response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress, entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(T entity)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://bytesynthix.com/api/{_apiEndPoint}/Update");
            var response = await httpClient.PutAsJsonAsync(httpClient.BaseAddress, entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://bytesynthix.com/api/{_apiEndPoint}/Delete/{id}");
            var response = await httpClient.DeleteAsync(httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

      
    }
}
