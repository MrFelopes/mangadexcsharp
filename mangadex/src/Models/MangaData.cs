using System.Text.Json.Serialization;

namespace mangadex.Models;

public class MangaData
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
        
    [JsonPropertyName("type")]
    public required string Type { get; set; }
        
    [JsonPropertyName("attributes")]
    public required MangaAttributes Attributes { get; set; }
}