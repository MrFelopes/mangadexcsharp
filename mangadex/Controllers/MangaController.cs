using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Web;


namespace mangadex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController(HttpClient httpClient) : ControllerBase
    {
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomManga()
        {
            const string baseUrl = "https://api.mangadex.org/manga";

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["limit"] = "100";
            query["availableTranslatedLanguage[]"] = "pt-br";

            var fullUrl = $"{baseUrl}?{query}";
            
            try
            {
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MangaDexAPI/1.0");
                var response = await httpClient.GetAsync(fullUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, $"Erro ao acessar a API. {response.StatusCode}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                var doc = JsonDocument.Parse(responseBody);
                var root = doc.RootElement;

                if (!root.TryGetProperty("data", out var dataArray) || dataArray.GetArrayLength() <= 0)
                    return NotFound("Nenhum mangá encontrado.");
                var random = new Random();
                var randomIndex = random.Next(dataArray.GetArrayLength());

                var randomManga = dataArray[randomIndex];
                return Ok(randomManga);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Erro ao fazer a requisição: {ex.Message}");
            }
        }
    }
}