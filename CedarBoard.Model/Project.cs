using System.Text.Json.Serialization;
using CedarBoard.Model.Poco;
using CedarBoard.Model.Accessor;

namespace CedarBoard.Model
{
   

    public sealed class Project(ITextFile textFile) : JsonFileBase
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
            if (File.Exists(NodeToTextPath(node))) throw new FileNotFoundException("同じ名前のノードを追加することは出来ません");
            NodeList.Add(node);
            textFile.SetData(NodeToTextPath(node), "");
        }
        
        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            File.Delete(NodeToTextPath(NodeList[index]));
            NodeList.RemoveAt(index);
        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Replace(NodePoco node, int index)
        {
            File.Move(NodeToTextPath(NodeList[index]), NodeToTextPath(node));
            NodeList[index] = node;
        }

        public override void Save()
        {
            textFile.SetData(Path + "/project.json", Serialize(this));
        }

        /// <summary>
        /// ノードを受け取り、それに対応したテキストファイルのパスを返す
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string NodeToTextPath(NodePoco node)
        {
            return Path + "/content/" + node.Name + ".txt";
        }
    }
}
