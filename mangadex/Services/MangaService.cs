using System.Text.Json;
using System.Web;
using mangadex.Models;

namespace mangadex.Services;

public class MangaService
{
    private readonly HttpClient _httpClient;
    public MangaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MangaDexAPI/1.0");
    }

    public async Task<List<MangaData>?> BuscarMangaAsync()
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["limit"] = "50";
        query["availableTranslatedLanguage[]"] = "pt-br";

        var fullUrl = $"https://api.mangadex.org/manga?{query}";
        
        var response = await _httpClient.GetAsync(fullUrl);
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var result = JsonSerializer.Deserialize<MangaResponse>(json, options);
        return result?.Data ?? new();
    }
}