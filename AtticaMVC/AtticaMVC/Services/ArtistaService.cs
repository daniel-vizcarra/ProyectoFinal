using AtticaMVC.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        response.EnsureSuccessStatusCode(); // Lanzará una excepción si el código de estado no es exitoso
        return await response.Content.ReadFromJsonAsync<IEnumerable<Artista>>();
    }

    public async Task<Artista> GetArtistaAsync(int id)
    {
        var response = await _httpClient.GetAsync($"Artistas/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Artista>();
    }

    public async Task CreateArtistaAsync(Artista artista)
    {
        var response = await _httpClient.PostAsJsonAsync("Artistas", artista);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateArtistaAsync(int id, Artista artista)
    {
        var response = await _httpClient.PutAsJsonAsync($"Artistas/{id}", artista);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteArtistaAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Artistas/{id}");
        response.EnsureSuccessStatusCode();
    }
}
