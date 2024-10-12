using System.Text.Json.Serialization;
using CedarBoard.Model.Poco;

namespace CedarBoard.Model
{
    public sealed class Project : JsonFileBase
    {
        [JsonPropertyName("nodeList")]
        public List<NodePoco>? NodeList { get; set; }


        /// <summary>
        /// 新しいノードを追加する
        /// </summary>
        /// <param name="node"></param>
        public void Add(NodePoco node)
        {
        }

        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {

        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Replace(NodePoco node, int index)
        {

        }
    }
}
