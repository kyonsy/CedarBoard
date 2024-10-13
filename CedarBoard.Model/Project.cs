using System.Text.Json.Serialization;
using CedarBoard.Model.Poco;
using CedarBoard.Model.Accessor;
using System.IO;

namespace CedarBoard.Model
{
   

    public sealed class Project
    {
        public string? Path {  get; set; }

        [JsonPropertyName("nodeList")]
        public required List<NodePoco> NodeList { get; set; }

        /// <summary>
        /// 新しいノードを追加する
        /// </summary>
        /// <param name="node"></param>
        public void Add(NodePoco node)
        {
            string fileName = Path + "/content/" + node.Name + ".txt";
            if (File.Exists(fileName)) throw new FileNotFoundException("同じ名前のノードを追加することは出来ません");
            NodeList.Add(node);
            File.WriteAllText(fileName,"");
        }

        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            File.Delete(Path + "/content/" + NodeList[index].Name + ".txt");
            NodeList.RemoveAt(index);
        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Replace(NodePoco node, int index)
        {
            NodeList[index] = node;
        }
    }
}
