using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 最初に生成されるノード
    /// </summary>
    public class OriginNode : INode
    {
        /// <summary>
        /// ノードのパス
        /// </summary>
        [JsonPropertyName("path")]
        public required string Path { get; set; }

        /// <summary>
        /// ノードのX座標
        /// </summary>
        [JsonPropertyName("x")]
        public required int X { get; set; }

        /// <summary>
        /// ノードのY座標
        /// </summary>
        [JsonPropertyName("y")]
        public required int Y { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        [JsonPropertyName("childNode")]
        public required List<int> ChildNode { get; set; }
    }
}
