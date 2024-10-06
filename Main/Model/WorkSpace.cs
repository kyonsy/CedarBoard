﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model
{
    internal sealed class WorkSpace
    {
        /// <summary>
        /// ワークスペースのパス
        /// </summary>
        public string Path {  get; set; }

        /// <summary>
        /// ワークスペースの設定
        /// </summary>
        public Setting Setting { get; set; }

        /// <summary>
        /// プロジェクトの名前
        /// </summary>
        public List<string> Projects { get; set; }

        /// <summary>
        /// シリアライズ(JSONにWorkSpaceの情報を書き出す)
        /// </summary>
        /// <param name="file"></param>
        public void Serialize(string file)
        {

        }

        /// <summary>
        /// デシリアライズ(WorkSpaceにJSONの情報を読み込む)
        /// </summary>
        /// <param name="file"></param>
        public void Deserialize(string file) { }

        /// <summary>
        /// 新しいプログラムを追加して返す
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Project Add(string project)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index) { }

        /// <summary>
        /// 指定されたプロジェクトを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Project GetProject(int index)
        {
            throw new NotImplementedException();
        }
    }
}
