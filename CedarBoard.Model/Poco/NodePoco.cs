using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    public sealed class NodePoco
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("point")]
        public required PointPoco Point { get; set; }

        [JsonPropertyName("childName")]
        public required List<int> ChildNode { get; set; }
    }
}
