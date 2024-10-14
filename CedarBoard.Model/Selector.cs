using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペースを選ぶためのもの。アプリケーションの起動と同時にインスタンス化される
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける</param>
    public sealed class Selector(ITextFile textFile) : JsonFileBase
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
        /// <exception cref="FileNotFoundException">同じ名前のディレクトリが出来て名前の衝突することを防ぐ</exception>
        public void Add(SettingPoco setting)
        {
            if (Directory.Exists(setting.Path)) throw new FileNotFoundException("同じパスに同じ名前のワークスペースがあります");
            Directory.CreateDirectory(setting.Path);
            textFile.SetData(setting.Path  + "/workspace.json",
                $@"{{""projectList"":[],""setting"":{Serialize(setting)}}}");
            PathList.Add(setting.Name, setting.Path);
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="workspace">削除したいワークスペースの名前</param>
        /// <exception cref="NullReferenceException">指定されてないワークスペースが入力されるのを防ぐ</exception>
        public void Remove(string workspace)
        {
            if (PathList[workspace] is null) throw new NullReferenceException("指定されたワークスペースは見つかりません");
            Directory.Delete(PathList[workspace], true);
            PathList.Remove(workspace);
        }

        /// <summary>
        /// 指定されたパスのワークスペースを返す
        /// </summary>
        /// <param name="path">欲しいワークスペースの名前</param>
        /// <returns>指定したワークスペース</returns>
        /// <exception cref="FormatException">上手く型変換が出来ないことを示す</exception>
        public Workspace GetWorkSpace(string path)
        {
            object obj = Deserialize(textFile.GetData(path + "/workspace.json"));
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
