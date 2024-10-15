namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// テスト用のモック。ファイル操作を間接的に表現
    /// </summary>
    public class TextFileMock : ITextFile
    {
        /// <summary>
        /// ファイルを表現。keyはファイルのパス、valueはファイルの中身
        /// </summary>
        public required Dictionary<string,string> FileDictionary { get; set; }


        /// <summary>
        /// ファイルの読み取りを表現
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <returns>ファイルの中身</returns>
        public string GetData(string file) => FileDictionary[file];

        /// <summary>
        /// ファイルの書き出しを表現
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">書き出す内容</param>
        public void SetData(string file, string value) => FileDictionary[file] = value;

        /// <summary>
        /// ファイルの生成を表現
        /// </summary>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public void Create(string file,string value) => FileDictionary.Add(file, value);

        /// <summary>
        /// ファイルの名前(path)の変更を表現
        /// </summary>
        /// <param name="file">名前を変えたいファイルの名前</param>
        /// <param name="newName">新しい名前</param>
        public void Rename(string file, string newName)
        {
            string value = FileDictionary[file];
            FileDictionary.Remove(file);
            FileDictionary.Add(newName, value);
        }

        /// <summary>
        /// ファイルの削除を表現
        /// </summary>
        /// <param name="file">削除するファイル</param>
        public void Delete(string file)
        {
            FileDictionary.Remove(file); 
        }

        /// <summary>
        /// ファイルのコピーを表現
        /// </summary>
        /// <param name="file">コピーするファイル</param>
        /// <param name="newName">コピー先のファイル</param>
        public void Copy(string file, string newName)
        {
            string value = FileDictionary[file];
            FileDictionary.Add(newName,value);
        }
    }
}
