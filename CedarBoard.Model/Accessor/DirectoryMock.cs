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
        public class Mock
        {
            /// <summary>
            /// 名前を表現する
            /// </summary>
            public required string Name { get; set; }

            /// <summary>
            /// ディレクトリが圧縮されているか示す
            /// </summary>
            public required bool Compressed { get; set; }
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
            DirectoryDictionary.Add(path,new() { 
                Compressed = false,
                Name = path
            });
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
    }
}
