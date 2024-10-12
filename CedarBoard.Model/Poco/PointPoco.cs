using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    public class PointPoco
    {
        [JsonPropertyName("x")]
        public required int X { get; set; }

        [JsonPropertyName("y")]
        public required int Y { get; set; }
    }
}
