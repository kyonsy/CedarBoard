// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
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
        [JsonInclude]
        public Dictionary<string, INode> NodeDictionary { get; } = [];


        /// <summary>
        /// プロジェクトのパス
        /// </summary>
        [JsonInclude]
        internal string Path { get; }

        /// <summary>
        /// ファイル操作オブジェクト
        /// </summary>
        [JsonIgnore]
        internal ITextFile? TextFile { get; set; } = new TextFileMock();

        /// <summary>
        /// Jsonからデシリアライズするときに使われるデフォルトコンストラクタ
        /// </summary>
        [JsonConstructor]
        public Project(string path, Dictionary<string, INode> nodeDictionary)
        {
            // テスト用
            Path = path;
            NodeDictionary = nodeDictionary;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="textFile">テキストファイルのインタフェース</param>
        /// <param name="path">プロジェクトのパス</param>
        public Project(ITextFile textFile, string path)
        {
            TextFile = textFile;
            Path = path;
            Add(new(100.0, 100.0));
        }

        /// <summary>
        /// 新しいノードを追加する(2つ目以降)
        /// </summary>
        /// <param name="nodeName">追加するノード</param>
        /// <param name="parentNodeName">親ノードの名前</param>
        /// <param name="point">ノードの座標</param>
        /// <exception cref="ArgumentException">始めのノードの追加に使えなくする</exception>
        public void Add(string nodeName, string parentNodeName, Point point)
        {
            if (NodeDictionary.Count == 0)
                throw new ArgumentException("始めのノードを追加するときはAdd(int x,int y)を使ってください");
            INode node = new Node()
            {
                ChildNode = [],
                ParentNode = parentNodeName,
                Path = @$"{Path}\{nodeName}.txt",
                Point = point,
                Message = "",
                Data = DateTime.Now,
                Name = nodeName
            };
            NodeDictionary.Add(nodeName, node);
            NodeDictionary[parentNodeName].ChildNode.Add(nodeName);
            TextFile?.Copy(NodeDictionary[parentNodeName].Path, node.Path);
            TextFile?.SetReadOnly(NodeDictionary[parentNodeName].Path);
        }

        /// <summary>
        /// 一番最初のノードを追加する
        /// </summary>
        /// <exception cref="ArgumentException">二つ目以降の追加に使えなくする</exception>
        private void Add(Point point)
        {
            if (NodeDictionary.Count > 0)
                throw new ArgumentException(
                    "二つ目以降のノードを追加するときはAdd(string nodeName,string newNodeName,int x,int y)を使ってください"
                    );
            INode node = new OriginNode()
            {
                Path = @$"{Path}\origin.txt",
                ChildNode = [],
                Point = point,
                Message = "最初のノード",
                Data = DateTime.Now,
                Name = "origin"
            };
            NodeDictionary.Add("origin", node);

            TextFile?.Create(node.Path, "");
        }

        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="nodeName">削除するノードの名前</param>
        /// <param name="parentName">親ノードの名前</param>
        public void Remove(string nodeName, string parentName)
        {
            if (NodeDictionary[nodeName] is Node node)
            {
                INode parentNode = NodeDictionary[node.ParentNode];
                if (parentNode.ChildNode.Count == 0)
                {
                    TextFile?.DeleteReadOnly(parentNode.Path);
                }
                TextFile?.Delete(node.Path);
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
        /// <param name="message">変更前のノードのメッセージ</param>
        public void Rename(string nodeName, string newNodeName, string message)
        {
            if (nodeName == "origin") throw new Exception("原点ノードの名前は変更できません");
            Node node = (Node)NodeDictionary[nodeName] with { Path = $@"{Path}/{newNodeName}.txt", Name = newNodeName, Message = message };

            // 親ノードの中のノードの名前を変える
            INode parentNode = NodeDictionary[node.ParentNode];
            int index = parentNode.ChildNode.IndexOf(nodeName);
            List<string> children = parentNode.ChildNode;
            children[index] = newNodeName;
            if (parentNode is OriginNode originNode)
            {
                NodeDictionary[node.ParentNode] = originNode with { ChildNode = children };
            }
            else if (parentNode is Node normalNode)
            {
                NodeDictionary[node.ParentNode] = normalNode with { ChildNode = children };
            }

            foreach (var childName in node.ChildNode)
            {
                NodeDictionary[childName] = (Node)NodeDictionary[childName] with { ParentNode = newNodeName };
            }
            NodeDictionary.Remove(nodeName);
            NodeDictionary.Add(newNodeName, node);
        }

        /// <summary>
        /// ノードの名前からそこに紐づけられたテキストファイルのパスを取得する
        /// </summary>
        /// <param name="nodeName">ノードの名前</param>
        /// <returns>テキストファイルのパス</returns>
        public string GetNodePath(string nodeName)
        {
            return NodeDictionary[nodeName].Path;
        }
    }
}

