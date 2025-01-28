// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// ノードのインターフェイス
    /// </summary>
    [JsonDerivedType(typeof(Node),nameof(Node))]
    [JsonDerivedType(typeof(OriginNode),nameof(OriginNode))]
    public interface INode
    {
        /// <summary>
        /// ノードのパス
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// ノードの座標
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// 子ノードの名前
        /// </summary>
        public List<string> ChildNode { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// ノードの名前
        /// </summary>
        public string Name {  get; set; }
    }
}

