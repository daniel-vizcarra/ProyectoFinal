using AtticaMVC.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ObradeArteService
{
    private readonly HttpClient _httpClient;

    public ObradeArteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ObradeArte>> GetObrasAsync()
    {
        var response = await _httpClient.GetAsync("ObradeArtes");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<ObradeArte>>(new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<ObradeArte> GetObraAsync(int id)
    {
        var response = await _httpClient.GetAsync($"ObradeArtes/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ObradeArte>(new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task CreateObraAsync(ObradeArte obra)
    {
        var response = await _httpClient.PostAsJsonAsync("ObradeArtes", obra);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateObraAsync(int id, ObradeArte obra)
    {
        var response = await _httpClient.PutAsJsonAsync($"ObradeArtes/{id}", obra);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteObraAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"ObradeArtes/{id}");
        response.EnsureSuccessStatusCode();
    }
}
