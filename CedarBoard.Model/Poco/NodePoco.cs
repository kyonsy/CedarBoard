using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// ノードの情報を持っているPOCO
    /// </summary>
    public sealed class NodePoco
    {
        /// <summary>
        /// ノードの名前
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// ノードの座標
        /// </summary>
        [JsonPropertyName("point")]
        public required PointPoco Point { get; set; }

        /// <summary>
        /// 子ノードの番号
        /// </summary>
        [JsonPropertyName("childName")]
        public required List<int> ChildNode { get; set; }
    }
}
