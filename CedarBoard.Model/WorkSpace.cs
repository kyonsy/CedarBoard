using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペース
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作のためのオブジェクト</param>
    /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>
    public sealed class Workspace(ITextFile textFile,IDirectory directory) : JsonFileBase
    {
        ///<summary>
        /// 設定
        /// </summary>
        [JsonPropertyName("setting")]
        public required SettingPoco Setting { get; set; }

        /// <summary>
        /// プロジェクトの名前のディクショナリ。keyはディレクトリの名前、valueはそのパス
        /// </summary>
        [JsonPropertyName("projectList")]
        public required Dictionary<string,string> ProjectDictionary { get; set; }


        /// <summary>
        /// 新しいプロジェクトを追加する
        /// </summary>
        /// <param name="project">プロジェクトの名前</param>
        public void Add(string project)
        {
            ProjectDictionary.Add(project, Setting.Path + "/" + project);
            directory.Create(ProjectDictionary[project]);
            textFile.Create(ProjectDictionary[project] + "/project.json","[]");
            directory.Create(ProjectDictionary[project] + "/" + "content");
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="project">削除したいプロジェクトの名前</param>
        public void Remove(string project) {
            directory.Delete(ProjectDictionary[project]);
            ProjectDictionary.Remove(project);
        }

        /// <summary>
        /// 指定されたプロジェクトを返す
        /// </summary>
        /// <param name="project">欲しいプロジェクトの名前</param>
        /// <returns>指定されたプロジェクト</returns>
        /// <exception cref="FormatException">上手く型変換が出来ないことを示す</exception>
        public Project GetProject(string project)
        {
            object obj = Deserialize(textFile.GetData(ProjectDictionary[project] + "/project.json"));
            Project newProject = obj as Project ??
                throw new FormatException("プロジェクトに変換できません");
            newProject.Path = ProjectDictionary[project];
            return newProject;
        }

        /// <summary>
        /// ワークスペースの状態を保存する
        /// </summary>
        public override void Save()
        {
            textFile.SetData(Setting.Path+"/workspace.json",Serialize(this));
        }
    }
}
