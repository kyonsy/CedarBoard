using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    public sealed class SettingPoco
    {
        [JsonPropertyName("format")]
        public required string Format { get; set; }

        [JsonPropertyName("editor")]
        public required string Editor { get; set; }

        [JsonPropertyName("encode")]
        public required string Encode { get; set; }

        [JsonPropertyName("languege")]
        public required string Language { get; set; }

        [JsonPropertyName("auther")]
        public required string Author { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("createdDate")]
        public required string CreatedDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public required string UpdatedDate { get; set; }

        [JsonPropertyName("path")]
        public required string Path { get; set; }

        [JsonPropertyName("message")]
        public required string Message { get; set; }
    }
}
