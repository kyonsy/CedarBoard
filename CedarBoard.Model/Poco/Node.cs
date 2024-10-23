using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 子ノード
    /// </summary>
    public sealed class Node : INode
    {
        /// <summary>
        /// ノードのパス
        /// </summary>
        [JsonPropertyName("path")]
        public required string Path { get; set; }

        /// <summary>
        /// ノードの座標
        /// </summary>
        [JsonPropertyName("point")]
        public required Point Point { get; set; }

        /// <summary>
        /// 親ノードの名前
        /// </summary>
        [JsonPropertyName("parentNode")]
        public required string ParentNode { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        [JsonPropertyName("childNode")]
        public required List<string> ChildNode { get; set; }
    }
}
