using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペース
    /// </summary>
    /// <param name="textFile">テスト用と本番用で使い分ける</param>
    public sealed class Workspace(ITextFile textFile) : JsonFileBase
    {
        ///<summary>
        /// 設定
        /// </summary>
        [JsonPropertyName("setting")]
        public required SettingPoco Setting { get; set; }

        /// <summary>
        /// プロジェクトの名前のディクショナリ
        /// </summary>
        [JsonPropertyName("projectList")]
        public required Dictionary<string,string> ProjectDictionary { get; set; }


        /// <summary>
        /// 新しいプログラムを追加する
        /// </summary>
        /// <param name="project">プロジェクトの名前</param>
        /// <exception cref="KeyNotFoundException">同じ名前のプロジェクトが出来るのを防ぐ</exception>
        public void Add(string project)
        {
            if (ProjectDictionary.ContainsKey(project)) throw new KeyNotFoundException("同じ名前のプロジェクトが既に存在しています"); 
            ProjectDictionary.Add(project, Setting.Path + "/" + project);
            Directory.CreateDirectory(ProjectDictionary[project]);
            File.WriteAllText(ProjectDictionary[project] + "/project.json","[]");
            Directory.CreateDirectory(ProjectDictionary[project] + "/" + "content");
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="project">削除したいプロジェクトの名前</param>
        ///  <exception cref="KeyNotFoundException">無効なキーの入力を防ぐ</exception>
        public void Remove(string project) {
            if (!ProjectDictionary.TryGetValue(project, out string? value)) throw new KeyNotFoundException("指定されたキーが見つかりません");
            Directory.Delete(value, true);
            ProjectDictionary.Remove(project);
        }

        /// <summary>
        /// 指定されたプロジェクトを返す
        /// </summary>
        /// <param name="project">欲しいプロジェクトの名前</param>
        /// <returns>指定されたプロジェクト</returns>
        ///  <exception cref="KeyNotFoundException">無効なキーの入力を防ぐ</exception>
        /// <exception cref="FormatException">上手く型変換が出来ないことを示す</exception>
        public Project GetProject(string project)
        {
            if (!ProjectDictionary.TryGetValue(project, out string? value)) throw new KeyNotFoundException("指定されたキーが見つかりません");
            object obj = Deserialize(textFile.GetData(value + "/project.json"));
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
