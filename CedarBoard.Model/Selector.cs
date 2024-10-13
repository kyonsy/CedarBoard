using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペースを選ぶためのもの
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける</param>
    public sealed class Selector(ITextFile textFile) : JsonFileBase
    {
        [JsonPropertyName("pathList")]
        public required Dictionary<string,string> PathList { get; set; }

        /// <summary>
        /// 新しいワークスペースを追加する
        /// </summary>
        /// <param name="setting">新しいワークスペースの設定</param>
        /// <returns>新しいワークスペース</returns>
        public void Add(SettingPoco setting)
        {
            Directory.CreateDirectory(setting.Path);
            textFile.SetData(setting.Path  + "/workspace.json",
                $@"{{""projectList"":[],""setting"":{Serialize(setting)}}}");
            PathList.Add(setting.Name, setting.Path);
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="path">削除したいワークスペースの名前</param>
        public void Remove(string workSpaceName)
        {
            Directory.Delete(PathList[workSpaceName], true);
            PathList.Remove(workSpaceName);
        }

        /// <summary>
        /// 指定されたパスのワークスペースを返す
        /// </summary>
        /// <param name="path">欲しいワークスペースの名前</param>
        /// <returns>指定したワークスペース</returns>
        /// <exception cref="FormatException"></exception>
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
            textFile.SetData(appPath, Serialize(this));
        }
    }
}
