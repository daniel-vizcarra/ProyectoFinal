using AtticaMAUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AtticaMAUI.Services
{
    public class ArtistaService
    {
        private readonly HttpClient _httpClient;

        public ArtistaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Artista>> GetArtistasAsync()
        {
            var response = await _httpClient.GetAsync("Artistas");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Artista>>();
        }

        public async Task<Artista> GetArtistaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Artistas/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Artista>();
        }
    }
}
