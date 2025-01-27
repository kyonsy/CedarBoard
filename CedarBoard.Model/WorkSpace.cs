using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペース
    /// </summary>
  
    public sealed class Workspace : JsonFileBase
    {
        /// <summary>
        /// workspace.jsonに紐付けられたPOCO
        /// </summary>
        public WorkspacePoco WorkspacePoco { get;}

        /// <summary>
        /// ファイル操作用オブジェクト
        /// </summary>
        internal ITextFile TextFile { get; }

        /// <summary>
        /// ディレクトリ操作用オブジェクト
        /// </summary>
        internal IDirectory Directory { get; }


        /// <summary>
        /// ワークスペースのパス
        /// </summary>
        private string Path { get; }

        /// <summary>
        /// ワークスペースのコンストラクタ
        /// </summary>
        /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作のためのオブジェクト</param>
        /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>
        /// <param name="path">ワークスペースのパス</param>
        public Workspace(ITextFile textFile, IDirectory directory, string path)
        {
            TextFile = textFile;
            Directory = directory;
            Path = path;
            WorkspacePoco = Deserialize(TextFile.GetData($@"{Path}\workspace.json"));
        }

        /// <summary>
        /// ワークスペースのコンストラクタ。デバッグ用
        /// </summary>
        /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作のためのオブジェクト</param>
        /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>
        /// <param name="path">ワークスペースのパス</param>
        /// <param name="workspacePoco">ワークスペースのPoco</param>
        public Workspace(ITextFile textFile, IDirectory directory, string path,WorkspacePoco workspacePoco)
        {
            TextFile = textFile;
            Directory = directory;
            Path = path;
            WorkspacePoco = workspacePoco;
        }

        /// <summary>
        /// プロジェクト名を変更する
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="newProjectName"></param>
        public void Rename(string projectName, string newProjectName)
        {
            Project project = WorkspacePoco.ProjectDictionary[projectName];
            WorkspacePoco.ProjectDictionary[newProjectName] = project;
            WorkspacePoco.ProjectDictionary.Remove(projectName);
        }

        /// <summary>
        /// 新しいプロジェクトを追加する
        /// </summary>
        /// <param name="projectName">プロジェクトの名前</param>
        public void Add(string projectName)
        {
            string newPath = @$"{Path}\{projectName}";
            Directory.Create(newPath);
            WorkspacePoco.ProjectDictionary.Add(projectName, new(TextFile, newPath));
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="projectName">削除したいプロジェクトの名前</param>
        public void Remove(string projectName)
        {
            Directory.Delete(@$"{Path}\{projectName}");
            WorkspacePoco.ProjectDictionary.Remove(projectName);
        }

        /// <summary>
        /// 指定したノード(に紐図けられたテキスト)を開く
        /// </summary>
        /// <param name="projectName">プロジェクトの名前</param>
        /// <param name="nodeName">指定したノードの名前</param>
        public void Open(string projectName,string nodeName)
        {
            ProcessStartInfo psi = new()
            {
                FileName = WorkspacePoco.Setting.Editor,
                Arguments = WorkspacePoco.ProjectDictionary[projectName].GetNodePath(nodeName),
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            using (Process.Start(psi)) { } ;
        }

        /// <summary>
        /// ワークスペースの状態を保存する
        /// </summary>
        public override void Save()
        {
            TextFile.SetData(@$"{Path}\workspace.json",Serialize(WorkspacePoco));
        }

        /// <summary>
        /// ワークスペースのデータをデシリアライズする
        /// </summary>
        /// <param name="json"></param>
        /// <returns>WorlspaceのPoco</returns>
        /// <exception cref="FormatException">Json文字列を認識できない</exception>
        protected override WorkspacePoco Deserialize(string json)
        {
            WorkspacePoco sel = JsonSerializer.Deserialize<WorkspacePoco>(json, GetOptions()) ??
                throw new FormatException("Json文字列として認識できません");
            foreach(var keyValuePair in sel.ProjectDictionary)
            {
                keyValuePair.Value.TextFile = TextFile;
            }
            return sel;
        }
    }
}
