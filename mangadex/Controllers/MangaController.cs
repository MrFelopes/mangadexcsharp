using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;


namespace mangadex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {

        private readonly HttpClient _httpClient;

        public MangaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomManga()
        {
            string baseURL = "https://api.mangadex.org/manga";

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["limit"] = "100";
            query["availableTranslatedLanguage[]"] = "pt-br";

            string fullURL = $"{baseURL}?{query}";
            //return Ok(fullURL);
            try
            {
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MangaDexAPI/1.0");
                HttpResponseMessage response = await _httpClient.GetAsync(fullURL);
                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, $"Erro ao acessar a API. {response.StatusCode}");
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                JsonDocument doc = JsonDocument.Parse(responseBody);
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("data", out JsonElement dataArray) && dataArray.GetArrayLength() > 0)
                {
                    var random = new Random();
                    int randomIndex = random.Next(dataArray.GetArrayLength());

                    JsonElement randomManga = dataArray[randomIndex];
                    return Ok(randomManga);
                }
                return NotFound("Nenhum mangá encontrado.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Erro ao fazer a requisição: {ex.Message}");
            }
        }
    }
}