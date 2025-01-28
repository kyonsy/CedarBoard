// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using System.Collections.Generic;

namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// ディレクトリを表現するMock
    /// </summary>
    public class DirectoryMock : IDirectory
    {
        /// <summary>
        /// ディレクトリの内部構造
        /// </summary>
        public class Mock()
        {
            /// <summary>
            /// ディレクトリが圧縮されているか示す
            /// </summary>
            public bool Compressed { get; set; } = false;
        }

        /// <summary>
        /// ディレクトリの集合を仮想的に再現
        /// </summary>
        public Dictionary<string,Mock> DirectoryDictionary { get; set; } = [];

        /// <summary>
        /// ディレクトリの生成を仮想的に表現
        /// </summary>
        /// <param name="path">生成するディレクトリのパス</param>
        public void Create(string path)
        {
            DirectoryDictionary.Add(path,new());
        }

        /// <summary>
        /// ディレクトリの削除を仮想的に表現
        /// </summary>
        /// <param name="path">削除したいディレクトリのパス</param>
        public void Delete(string path)
        {
            DirectoryDictionary.Remove(path);
        }

        /// <summary>
        /// ディレクトリの圧縮を表現
        /// </summary>
        /// <param name="path"></param>
        public void Compress(string path)
        {
            DirectoryDictionary[path].Compressed = true;
        }

        /// <summary>
        /// ディレクトリの解凍を表現
        /// </summary>
        /// <param name="path"></param>
        public void Unfreeze(string path)
        {
            DirectoryDictionary[path].Compressed = false;
        }

        /// <summary>
        /// あるディクショナリがあるかどうか調べる
        /// </summary>
        /// <param name="direcory"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Exists(string direcory)
        {
            return DirectoryDictionary.ContainsKey(direcory);
        }
    }
}

