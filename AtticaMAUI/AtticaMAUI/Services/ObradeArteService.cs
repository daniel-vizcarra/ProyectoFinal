using AtticaMAUI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AtticaMAUI.Services
{
    public class ObradeArteService
    {
        private readonly HttpClient _httpClient;

        public ObradeArteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ObradeArte>> GetObrasAsync()
        {
            var response = await _httpClient.GetAsync("api/ObradeArtes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ObradeArte>>();
        }

        public async Task<ObradeArte> GetObraAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/ObradeArtes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ObradeArte>();
        }

        public async Task CreateObraAsync(ObradeArte obra)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ObradeArtes", obra);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateObraAsync(int id, ObradeArte obra)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/ObradeArtes/{id}", obra);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteObraAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/ObradeArtes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
