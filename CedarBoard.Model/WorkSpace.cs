using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.IO;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    public sealed class WorkSpace(ITextFile textFile) : JsonFileBase
    {
        public string? Path { get; set; }

        [JsonPropertyName("setting")]
        public required SettingPoco Setting { get; set; }

        [JsonPropertyName("projectList")]
        public required List<string> ProjectList { get; set; }


        /// <summary>
        /// 新しいプログラムを追加する
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(string project)
        {
            ProjectList.Add(project);
            Directory.CreateDirectory(Path + "/" + project);
            File.WriteAllText(Path + "/" + project + "/project.json","[]");
            Directory.CreateDirectory(Path + "/" + project+ "/" + "content");
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index) { 
            Directory.Delete(Path + "/" + ProjectList[index], true);
            ProjectList.RemoveAt(index);
        }

        /// <summary>
        /// 指定されたプロジェクトを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Project GetProject(int index)
        {
            object obj = Deserialize(textFile.GetData(Path + "/" + ProjectList[index] + "/project.json"));
            Project project = obj as Project ??
                throw new NotImplementedException("ワークスペースに変換できません");
            project.Path = Path + ProjectList[index];
            return project;
        }
    }
}
