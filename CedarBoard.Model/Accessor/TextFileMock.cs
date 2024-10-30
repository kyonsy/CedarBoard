namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// テスト用のモック。ファイル操作を間接的に表現
    /// </summary>
    public class TextFileMock : ITextFile
    {
        /// <summary>
        /// ファイルを表現するMock
        /// </summary>
        public class Mock(string value)
        {
            /// <summary>
            /// ファイルの中身を表現する
            /// </summary>
            public string Value { get; set; } = value;

            /// <summary>
            /// ファイルが読み取り専用か示す
            /// </summary>
            public bool ReadOnly { get; set; } = false;
        }

        /// <summary>
        /// ファイルを表現。keyはファイルのパス、valueはファイルの中身
        /// </summary>
        public Dictionary<string, Mock> FileDictionary { get; set; } = [];


        /// <summary>
        /// ファイルの読み取りを表現
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <returns>ファイルの中身</returns>
        public string GetData(string file) => FileDictionary[file].Value;

        /// <summary>
        /// ファイルの書き出しを表現
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">書き出す内容</param>
        public void SetData(string file, string value) {
            FileDictionary[file].Value = value;
        }

        /// <summary>
        /// ファイルの生成を表現
        /// </summary>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public void Create(string file,string value)
        {
            FileDictionary.Add(file, new(value));
            
        }

        /// <summary>
        /// ファイルの名前(path)の変更を表現
        /// </summary>
        /// <param name="file">名前を変えたいファイルの名前</param>
        /// <param name="newFile">新しい名前</param>
        public void Rename(string file, string newFile)
        {
            string value = FileDictionary[file].Value;
            FileDictionary.Remove(file);
            FileDictionary.Add(newFile, new(value));
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
        /// <param name="newFile">コピー先のファイル</param>
        public void Copy(string file, string newFile)
        {
            string value = FileDictionary[file].Value;
            FileDictionary.Add(newFile, new(value));
        }

        /// <summary>
        /// ファイルに読み取り専用属性を追加する
        /// </summary>
        /// <param name="file"></param>
        public void SetReadOnly(string file)
        {
            FileDictionary[file].ReadOnly = true;
        }

        /// <summary>
        /// ファイルの読み取り専用属性を削除する
        /// </summary>
        /// <param name="file"></param>
        public void DeleteReadOnly(string file)
        {
            FileDictionary[file].ReadOnly = false;
        }

        /// <summary>
        /// 指定したファイルが存在しているかどうか調べる
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool Exists(string file)
        {
            return FileDictionary.ContainsKey(file);
        }
    }
}
