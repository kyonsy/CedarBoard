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
        public void Add(string path, SettingPoco setting)
        {
            Directory.CreateDirectory(path);
            File.WriteAllText(path  + "/workspace.json", CreateJsonTemplete(setting));
            PathList.Add(setting.Name, path);
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
        public WorkSpace GetWorkSpace(string path)
        {
            object obj = Deserialize(textFile.GetData(path + "/workspace.json"));
            WorkSpace workSpace = obj as WorkSpace ?? 
                throw new NotImplementedException("ワークスペースに変換できません");
            workSpace.Path = path;
            return workSpace;
        }


        private static string CreateJsonTemplete(SettingPoco setting)
        {

            return $@"{{""projectList"":[],""setting"":{Serialize(setting)}}}";
        }
    }
}
