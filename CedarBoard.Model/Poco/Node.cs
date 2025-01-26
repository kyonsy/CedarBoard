using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 子ノード
    /// </summary>
    public sealed record Node : INode
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
        /// 親ノードの名前
        /// </summary>
        [JsonInclude]
        public required string ParentNode { get; set; }


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


        /// <summary>
        /// 作成日時
        /// </summary>
        [JsonInclude]
        public required DateTime Data { get; set; }

        /// <summary>
        /// ノードの名前
        /// </summary>
        [JsonInclude]
        public required string Name { get; set; }
    }
}
