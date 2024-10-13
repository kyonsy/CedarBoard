using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.IO;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける</param>
    public sealed class Workspace(ITextFile textFile) : JsonFileBase
    {
        
        /// <summary>
        /// 設定
        /// </summary>
        [JsonPropertyName("setting")]
        public required SettingPoco Setting { get; set; }

        /// <summary>
        /// プロジェクトの名前のリスト
        /// </summary>
        [JsonPropertyName("projectList")]
        public required List<string> ProjectList { get; set; }


        /// <summary>
        /// 新しいプログラムを追加する
        /// </summary>
        /// <param name="project">プロジェクトの名前</param>
        public void Add(string project)
        {
            ProjectList.Add(project);
            Directory.CreateDirectory(ProjectToPath(project));
            File.WriteAllText(ProjectToPath(project) + "/project.json","[]");
            Directory.CreateDirectory(ProjectToPath(project) + "/" + "content");
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="index">削除したいプロジェクトの番号</param>
        public void Remove(int index) { 
            Directory.Delete(ProjectToPath(ProjectList[index]), true);
            ProjectList.RemoveAt(index);
        }

        /// <summary>
        /// 指定されたプロジェクトを返す
        /// </summary>
        /// <param name="index">欲しいプロジェクトの番号</param>
        /// <returns>指定されたプロジェクト</returns>
        /// <exception cref="FormatException"></exception>
        public Project GetProject(int index)
        {
            object obj = Deserialize(textFile.GetData(ProjectToPath(ProjectList[index]) + "/project.json"));
            Project project = obj as Project ??
                throw new FormatException("プロジェクトに変換できません");
            project.Path = ProjectToPath(ProjectList[index]);
            return project;
        }

        /// <summary>
        /// ワークスペースの状態を保存する
        /// </summary>
        public override void Save()
        {
            textFile.SetData(Setting.Path+"/workspace.json",Serialize(this));
        }

        /// <summary>
        /// プロジェクトを受け取って、そのパスを返す
        /// </summary>
        /// <param name="project">パスが欲しいプロジェクトの名前</param>
        /// <returns>プロジェクトのパス</returns>
        private string ProjectToPath(string project)
        {
            return Setting.Path + "/" + project;
        }
    }
}
