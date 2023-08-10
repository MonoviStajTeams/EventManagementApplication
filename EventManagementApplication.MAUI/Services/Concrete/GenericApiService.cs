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
        private readonly HttpClient _httpClient;

        public GenericApiService(string apiEndpoint)
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + $"{apiEndpoint}");
        }

        public async Task<T> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/GetById/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://10.0.2.2:5072/api/Event/GetAll");
                var response = await httpClient.GetAsync(_httpClient.BaseAddress);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
                }
                else
                {
                    // API'den başarısız yanıt alındı.
                    // İstenilen işlemi yapabilir veya uygun bir hata mesajı döndürebilirsiniz.
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
            var response = await _httpClient.PostAsJsonAsync("/Create", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(T entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"/Update/", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }

      
    }
}
