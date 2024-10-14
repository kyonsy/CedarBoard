using System.Text.Json.Serialization;
using CedarBoard.Model.Poco;
using CedarBoard.Model.Accessor;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
namespace CedarBoard.Model
{
   
    /// <summary>
    /// プロジェクトのデータとそれに対する操作
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける</param>
    internal sealed class Project(ITextFile textFile) : JsonFileBase
    {
        /// <summary>
        /// プロジェクトのあるパス
        /// </summary>
        public string? Path {  get; set; }

        /// <summary>
        /// ノードのリスト
        /// </summary>
        [JsonPropertyName("nodeList")]
        public required List<NodePoco> NodeList { get; set; }

        /// <summary>
        /// 新しいノードを追加する
        /// </summary>
        /// <param name="node">追加するノード</param>
        public void Add(NodePoco node)
        {
            if (File.Exists(NodeToTextPath(node))) throw new FileNotFoundException("同じ名前のノードを追加することは出来ません");
            NodeList.Add(node);
            textFile.SetData(NodeToTextPath(node), "");
        }
        
        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="index">削除するノードの番号</param>
        public void Remove(int index)
        {
            File.Delete(NodeToTextPath(NodeList[index]));
            NodeList.RemoveAt(index);
        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node">変更後のノード</param>
        /// <param name="index">変更するノードの番号</param>
        public void Replace(NodePoco node, int index)
        {
            File.Move(NodeToTextPath(NodeList[index]), NodeToTextPath(node));
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
