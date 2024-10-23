using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// プロジェクトのデータとそれに対する操作
    /// </summary>
    public sealed class Project
    {
        /// <summary>
        /// ノードのディクショナリ
        /// </summary>
        [JsonPropertyName("nodes")]
        public Dictionary<string,INode> NodeDictionary { get; set; } = [];


        /// <summary>
        /// プロジェクトのパス
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; }

        /// <summary>
        /// ファイル操作オブジェクト
        /// </summary>
        [JsonIgnore]
        public ITextFile TextFile { get; } = new TextFileAccessor();


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="textFile"></param>
        /// <param name="path"></param>
        public Project(ITextFile textFile, string path)
        {
            TextFile = textFile;
            Path = path;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Project(string path)
        {
            Path = path;
        }


        /// <summary>
        /// 新しいノードを追加する(2つ目以降)
        /// </summary>
        /// <param name="nodeName">追加するノード</param>
        /// <param name="newNodeName">親ノードの番号</param>
        /// <param name="point">ノードの座標</param>
        /// <exception cref="ArgumentException">始めのノードの追加に使えなくする</exception>
        public void Add(string nodeName,string newNodeName,Point point)
        {
            if (NodeDictionary.Count == 0) 
                throw new ArgumentException("始めのノードを追加するときはAdd(int x,int y)を使ってください");
            INode node = new Node()
            {
                ChildNode = [],
                ParentNode = nodeName,
                Path = @$"{Path}\{newNodeName}.txt",
                Point = point,
            };
            NodeDictionary.Add(newNodeName, node);
            NodeDictionary[nodeName].ChildNode.Add(newNodeName);
            TextFile.Copy(NodeDictionary[nodeName].Path, node.Path);
            TextFile.SetReadOnly(NodeDictionary[nodeName].Path);
        }

        /// <summary>
        /// 一番最初のノードを追加する
        /// </summary>
        /// <exception cref="ArgumentException">二つ目以降の追加に使えなくする</exception>
        public void Add(Point point)
        {
            if(NodeDictionary.Count > 0) 
                throw new ArgumentException("二つ目以降のノードを追加するときはAdd(string nodeName,string newNodeName,int x,int y)を使ってください");
            INode node = new OriginNode(){
                Path = @$"{Path}\origin.txt",
                ChildNode = [],
                Point = point
            };
            NodeDictionary.Add("origin", node);
            TextFile.Create(node.Path,""); 
        }

        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="nodeName">削除するノードの名前</param>
        public void Remove(string nodeName)
        {
            if (NodeDictionary[nodeName] is Node node)
            {
                INode parentNode = NodeDictionary[node.ParentNode];
                if (parentNode.ChildNode.Count == 0)
                {
                    TextFile.DeleteReadOnly(parentNode.Path);
                }
                TextFile.Delete(node.Path);
                NodeDictionary.Remove(nodeName);
            }
            else
            {
                throw new Exception("原点ノードは削除できません");
            }
        }

        /// <summary>
        /// 指定されたノードの名前を変更する
        /// </summary>
        /// <param name="nodeName">変更前のノードの名前</param>
        /// <param name="newNodeName">変更後のノードの名前</param>
        public void Rename(string nodeName,string newNodeName)
        {
            if(nodeName =="origin") throw new Exception("原点ノードの名前は変更できません");
            INode node = NodeDictionary[nodeName];
            node.Path = $@"{Path}/{newNodeName}.txt";
            NodeDictionary.Remove(nodeName);
            NodeDictionary.Add(newNodeName, node);
            TextFile.Rename(NodeDictionary[nodeName].Path, NodeDictionary[newNodeName].Path);  
        }

        /// <summary>
        /// ノードの名前からそこに紐づけられたテキストファイルのパスを取得する
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetNodePath(string nodeName)
        {
            return NodeDictionary[nodeName].Path;
        }
    }
}
