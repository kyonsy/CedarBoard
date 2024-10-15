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
        /// ワークスペースの名前をキーにとそのパスを保持する
        /// </summary>
        [JsonPropertyName("pathList")]
        public required Dictionary<string,string> PathList { get; set; }

        /// <summary>
        /// 新しいワークスペースを追加する
        /// </summary>
        /// <param name="setting">新しいワークスペースの設定</param>
        /// <returns>新しいワークスペース</returns>
        public void Add(SettingPoco setting)
        {
            directory.Create(setting.Path);
            textFile.Create(setting.Path  + "/workspace.json",
                $@"{{""projectList"":[],""setting"":{Serialize(setting)}}}");
            PathList.Add(setting.Name, setting.Path);
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="workspace">削除したいワークスペースの名前</param>
        public void Remove(string workspace)
        {
            directory.Delete(PathList[workspace]);
            PathList.Remove(workspace);
        }

        /// <summary>
        /// 指定されたパスのワークスペースを返す
        /// </summary>
        /// <param name="workspace">欲しいワークスペースの名前</param>
        /// <returns>指定したワークスペース</returns>
        public Workspace GetWorkSpace(string workspace)
        {
            object obj = Deserialize(textFile.GetData(PathList[workspace] + "/workspace.json"));
            Workspace workSpace = obj as Workspace ?? 
                throw new FormatException("ワークスペースに変換できません");
            return workSpace;
        }

        /// <summary>
        /// セレクタの情報を保存する
        /// </summary>
        public override void Save()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            textFile.SetData(appPath + "/setting.json", Serialize(this));
        }
    }
}
