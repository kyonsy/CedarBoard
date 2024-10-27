using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// ノードのインターフェイス
    /// </summary>
    [JsonDerivedType(typeof(Node))]
    [JsonDerivedType(typeof(OriginNode))]
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
    }
}
