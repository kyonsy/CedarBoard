using System.Runtime.CompilerServices;
using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json;
using System.Text.Json.Serialization;
[assembly:InternalsVisibleTo("CedarBoardTest.Tests")]
namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペースを選ぶためのもの。アプリケーションの起動と同時にインスタンス化される
    /// </summary>
    public sealed class WorkspaceSelector : JsonFileBase
    {
        /// <summary>
        /// setting.jsonに紐付けられたPOCO
        /// </summary>
        [JsonInclude]
        public SelectorPoco SelectorPoco { get; set; }

        /// <summary>
        /// ファイル操作用オブジェクト
        /// </summary>
        [JsonIgnore]
        internal ITextFile TextFile { get; }

        /// <summary>
        /// ディレクトリ操作用オブジェクト
        /// </summary>
        [JsonIgnore]
        internal IDirectory Directory { get; }

        /// <summary>
        /// setting.jsonがあるパス
        /// </summary>
        private string SettingPath { get; } = @$"{AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\')}\setting.json";

        /// <summary>
        /// セレクタのコンストラクタ
        /// </summary>
        /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作用のオブジェクト</param>
        /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>
        public WorkspaceSelector(ITextFile textFile, IDirectory directory)
        {
            TextFile = textFile;
            Directory = directory;
            SelectorPoco = GetSelectorPoco();   
        }

        /// <summary>
        /// 新しいワークスペースを追加する。ここでWorkspaceがインスタンス化されるわけではない点に注意
        /// </summary>
        /// <param name="setting">新しいワークスペースの設定</param>
        /// <param name="path">ワークスペースのパス</param>
        /// <returns>新しいワークスペース</returns>
        public void Add(Setting setting,string path)
        {
            Directory.Create(path);
            WorkspacePoco wPoco = new() { Setting = setting,ProjectDictionary = [] };
            TextFile.Create(@$"{path}\workspace.json",Serialize(wPoco));
            SelectorPoco.PathDictionary.Add(setting.Name, path);
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="workspace">削除したいワークスペースの名前</param>
        public void Remove(string workspace)
        {
            Directory.Delete(SelectorPoco.PathDictionary[workspace]);
            SelectorPoco.PathDictionary.Remove(workspace);
        }

        /// <summary>
        /// 指定したワークスペースの名前を変える
        /// </summary>
        /// <param name="workspaceName"></param>
        /// <param name="newWorkspaceName"></param>
        public void Rename(string workspaceName,string newWorkspaceName)
        {
            Workspace workspace = GetWorkSpace(workspaceName);
            workspace.WorkspacePoco.Setting.Name = newWorkspaceName;
            workspace.Save();
            SelectorPoco.PathDictionary.Add(newWorkspaceName,SelectorPoco.PathDictionary[workspaceName]);
            SelectorPoco.PathDictionary.Remove(workspaceName);
            
        }


        /// <summary>
        /// 指定された名前のワークスペースを返す
        /// </summary>
        /// <param name="workspace">欲しいワークスペースの名前</param>
        /// <returns>指定したワークスペース</returns>
        public Workspace GetWorkSpace(string workspace)
        {
            string path = SelectorPoco.PathDictionary[workspace];
            return new Workspace(TextFile, Directory, path);
        }

        /// <summary>
        /// セレクタの情報を保存する
        /// </summary>
        public override void Save()
        {
            // string s = Serialize(this); // デバック用に作った変数
            TextFile.SetData(SettingPath, Serialize(SelectorPoco));
        }

        /// <summary>
        /// セレクタを作って返す
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        protected override SelectorPoco Deserialize(string json) {
            SelectorPoco sel = JsonSerializer.Deserialize<SelectorPoco>(json, GetOptions()) ??
                throw new FormatException("Json文字列として認識できません");
            return sel;
        }

        /// <summary>
        /// デシリアライズを行いSelectorPocoを返す
        /// </summary>
        /// <returns></returns>
        private SelectorPoco GetSelectorPoco() {
            if (TextFile.Exists(SettingPath))
            {
                return Deserialize(TextFile.GetData(SettingPath));
            }
            else
            {
                SelectorPoco poco = new() { PathDictionary = [] };
                TextFile.Create(SettingPath, Serialize(poco));
                return poco;
            }
        }
}
}
