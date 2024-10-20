using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 最初に生成されるノード
    /// </summary>
    public sealed class OriginNode : INode
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
        /// 子ノードの名前
        /// </summary>
        [JsonPropertyName("childNode")]
        public required List<int> ChildNode { get; set; }
    }
}
