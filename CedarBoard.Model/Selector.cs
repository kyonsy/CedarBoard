using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    public sealed class Selector(ITextFile textFile) : JsonFileBase
    {
        [JsonPropertyName("pathList")]
        public required Dictionary<string,string> PathList { get; set; }

        /// <summary>
        /// 新しいワークスペースを追加する
        /// </summary>
        /// <param name="path"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
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
        /// <param name="path"></param>
        public void Remove(string workSpaceName)
        {
            Directory.Delete(PathList[workSpaceName], true);
            PathList.Remove(workSpaceName);
        }

        /// <summary>
        /// 指定されたパスのワークスペースを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Workspace GetWorkSpace(string path)
        {
            object obj = Deserialize(textFile.GetData(path + "/workspace.json"));
            Workspace workSpace = obj as Workspace ?? 
                throw new NotImplementedException("ワークスペースに変換できません");
            return workSpace;
        }

        public override void Save()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            textFile.SetData(appPath, Serialize(this));
        }
    }
}
