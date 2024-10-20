using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペースを選ぶためのもの。アプリケーションの起動と同時にインスタンス化される
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作用のオブジェクト</param>
    /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>
    public sealed class Selector(ITextFile textFile,IDirectory directory) : JsonFileBase
    {
        /// <summary>
        /// ワークスペースの名前をキーに、そのパスを保持する
        /// </summary>
        [JsonPropertyName("pathList")]
        public Dictionary<string, string> PathDictionary { get; set; } = [];

        /// <summary>
        /// ファイル操作用オブジェクト
        /// </summary>
        public ITextFile TextFile { get; } = textFile;

        /// <summary>
        /// ディレクトリ操作用オブジェクト
        /// </summary>
        public IDirectory Directory { get; } = directory;

        /// <summary>
        /// 新しいワークスペースを追加する
        /// </summary>
        /// <param name="setting">新しいワークスペースの設定</param>
        /// <param name="path">ワークスペースのパス</param>
        /// <returns>新しいワークスペース</returns>
        public void Add(Setting setting,string path)
        {
            Directory.Create(path);
            TextFile.Create(@$"{path}\workspace.json",
                @$"{{""projectList"":[],""setting"":{Serialize(setting)}}}");
            PathDictionary.Add(setting.Name, path);
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="workspace">削除したいワークスペースの名前</param>
        public void Remove(string workspace)
        {
            Directory.Delete(PathDictionary[workspace]);
            PathDictionary.Remove(workspace);
        }

        /// <summary>
        /// 指定されたパスのワークスペースを返す
        /// </summary>
        /// <param name="workspace">欲しいワークスペースの名前</param>
        /// <returns>指定したワークスペース</returns>
        public Workspace GetWorkSpace(string workspace)
        {
            object obj = Deserialize(@$"{TextFile.GetData(PathDictionary[workspace])}\workspace.json");
            Workspace workSpace = new(TextFile, Directory, PathDictionary[workspace]) { 
                WorkspacePoco = (WorkspacePoco)obj 
            };
            return workSpace;
        }

        /// <summary>
        /// セレクタの情報を保存する
        /// </summary>
        public override void Save()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            TextFile.SetData(@$"{appPath}\setting.json", Serialize(this));
        }
    }
}
