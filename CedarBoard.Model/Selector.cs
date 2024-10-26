using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.IO;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペースを選ぶためのもの。アプリケーションの起動と同時にインスタンス化される
    /// </summary>
    /// <remarks>
    /// セレクタのコンストラクタ
    /// </remarks>
    /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作用のオブジェクト</param>
    /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>

    public sealed class Selector(ITextFile textFile, IDirectory directory) : JsonFileBase
    {
        /// <summary>
        /// setting.jsonに紐付けられたPOCO
        /// </summary>
        [JsonInclude]
        public required SelectorPoco SelectorPoco { get; set; }

        /// <summary>
        /// ファイル操作用オブジェクト
        /// </summary>
        [JsonIgnore]
        public ITextFile TextFile { get; } = textFile;

        /// <summary>
        /// ディレクトリ操作用オブジェクト
        /// </summary>
        [JsonIgnore]
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
                @$"{{""projectDictionary"":{{}},""setting"":{Serialize(setting)}}}");
            SelectorPoco.PathDictionary.Add(setting.Name, path);
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="workspace">削除したいワークスペースの名前</param>
        public void Remove(string workspace)
        {
            Directory.Delete(SelectorPoco.PathDictionary[workspace]);
            SelectorPoco.PathDictionary.Remove(workspace);
        }

        /// <summary>
        /// 指定されたパスのワークスペースを返す
        /// </summary>
        /// <param name="workspace">欲しいワークスペースの名前</param>
        /// <returns>指定したワークスペース</returns>
        public Workspace GetWorkSpace(string workspace)
        {
            return Creater.CreateWorkspace(@$"{SelectorPoco.PathDictionary[workspace]}\workspace.json");
        }

        /// <summary>
        /// セレクタの情報を保存する
        /// </summary>
        public override void Save()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            string s = Serialize(this);
            TextFile.SetData(@$"{appPath}\setting.json", Serialize(SelectorPoco));
        }
    }
}
