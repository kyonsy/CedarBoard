using System.Text.Json.Serialization;
using CedarBoard.Model.Poco;
using CedarBoard.Model.Accessor;

namespace CedarBoard.Model
{
   
    /// <summary>
    /// プロジェクトのデータとそれに対する操作
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける</param>
    public sealed class Project(ITextFile textFile) : JsonFileBase
    {
        /// <summary>
        /// プロジェクトのあるパス
        /// </summary>
        public string? Path {  get; set; }

        /// <summary>
        /// ノードのリスト
        /// </summary>
        [JsonPropertyName("nodeList")]
        public List<NodePoco> NodeList { get; set; } = new List<NodePoco>();

        /// <summary>
        /// 新しいノードを追加する(2つ目以降)
        /// </summary>
        /// <param name="node">追加するノード</param>
        /// <param name="index">親ノードの番号</param>
        public void Add(NodePoco node,int index)
        {
            textFile.Copy(NodeToTextPath(node), NodeToTextPath(NodeList[index]));
            NodeList.Add(node);
        }

        /// <summary>
        /// 一番最初のノードを追加する
        /// </summary>
        /// <param name="node">追加するノード</param>
        public void Add(NodePoco node)
        {
            textFile.Create(NodeToTextPath(node), "");
            NodeList.Add(node);
        }

        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="index">削除するノードの番号</param>
        public void Remove(int index)
        {
            textFile.Delete(NodeToTextPath(NodeList[index]));
            NodeList.RemoveAt(index);
        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node">変更後のノード</param>
        /// <param name="index">変更するノードの番号</param>
        public void Replace(NodePoco node, int index)
        {
            textFile.Rename(NodeToTextPath(NodeList[index]), NodeToTextPath(node));
            NodeList[index] = node;
        }

        /// <summary>
        /// プロジェクトの状態を保存する
        /// </summary>
        public override void Save()
        {
            textFile.SetData(Path + "/project.json", Serialize(this));
        }

        /// <summary>
        /// ノードを受け取り、それに対応したテキストファイルのパスを返す
        /// </summary>
        /// <param name="node">パスを知りたいノード</param>
        /// <returns>対応するパス</returns>
        private string NodeToTextPath(NodePoco node)
        {
            return Path + "/content/" + node.Name + ".txt";
        }
    }
}
