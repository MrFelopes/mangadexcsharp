using System.Text.Json.Serialization;

namespace mangadex.Models;

    public class MangaResponse
    {
        [JsonPropertyName("result")]
        public required string Result { get; set; }
        
        [JsonPropertyName("data")]
        public required List<MangaData> Data { get; set; }
    
    }