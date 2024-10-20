using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 子ノード
    /// </summary>
    public class Node : INode
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
        /// 親ノードの名前
        /// </summary>
        [JsonPropertyName("parentNode")]
        public required string ParentNode { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        [JsonPropertyName("childNode")]
        public required List<int> ChildNode { get; set; }
    }
}
