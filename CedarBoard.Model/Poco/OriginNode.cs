using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 最初に生成されるノード
    /// </summary>
    public sealed record OriginNode : INode
    {
        /// <summary>
        /// ノードのパス
        /// </summary>
        [JsonInclude]
        public required string Path { get; set; }


        /// <summary>
        /// ノードの座標
        /// </summary>
        [JsonInclude]
        public required Point Point { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        [JsonInclude]
        public required List<string> ChildNode { get; set; }


        /// <summary>
        /// メッセージ
        /// </summary>
        [JsonInclude]
        public required string Message { get; set; }
    }
}
