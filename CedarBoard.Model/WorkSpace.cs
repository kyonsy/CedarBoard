﻿using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Diagnostics;

namespace CedarBoard.Model
{
    /// <summary>
    /// ワークスペース
    /// </summary>
    /// <remarks>
    /// ワークスペースのコンストラクタ
    /// </remarks>
    /// <param name="textFile">テスト用と本番用で使い分ける。ファイル操作のためのオブジェクト</param>
    /// <param name="directory">テスト用と本番用で使い分ける。ディレクトリ操作のためのオブジェクト</param>
    /// <param name="path">ワークスペースのパス</param>
    public sealed class Workspace(ITextFile textFile, IDirectory directory, string path) : JsonFileBase
    {
        /// <summary>
        /// workspace.jsonに紐付けられたPOCO
        /// </summary>
        public required WorkspacePoco WorkspacePoco { get; set; }

        /// <summary>
        /// ファイル操作用オブジェクト
        /// </summary>
        public ITextFile TextFile { get; } = textFile;

        /// <summary>
        /// ディレクトリ操作用オブジェクト
        /// </summary>
        public IDirectory Directory { get; } = directory;


        /// <summary>
        /// ワークスペースのパス
        /// </summary>
        public string Path { get; } = path;

        /// <summary>
        /// 新しいプロジェクトを追加する
        /// </summary>
        /// <param name="projectName">プロジェクトの名前</param>
        public void Add(string projectName)
        {
            string newPath = @$"{Path}\{projectName}";
            WorkspacePoco.ProjectDictionary.Add(projectName, new(TextFile, newPath));
            Directory.Create(newPath);
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
        /// <param name="projectName"></param>
        /// <param name="nodeName"></param>
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
    }
}
