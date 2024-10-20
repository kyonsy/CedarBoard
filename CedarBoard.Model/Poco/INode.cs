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
        /// ノードのX座標
        /// </summary>
        [JsonPropertyName("x")]
        public  int X { get; set; }

        /// <summary>
        /// ノードのY座標
        /// </summary>
        [JsonPropertyName("y")]
        public int Y { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        [JsonPropertyName("childNode")]
        public List<int> ChildNode { get; set; }
    }
}
