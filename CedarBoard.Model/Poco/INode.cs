using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// ノードのインターフェイス
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// ノードのパス
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// ノードの座標
        /// </summary>
        [JsonPropertyName("point")]
        public Point Point { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        [JsonPropertyName("childNode")]
        public List<int> ChildNode { get; set; }
    }
}
