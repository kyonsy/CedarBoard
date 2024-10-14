namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// テスト用のモック。ファイル操作を間接的に表現
    /// </summary>
    public class TextFileMock : ITextFile
    {
        /// <summary>
        /// ファイルの中身を表現
        /// </summary>
        public required string Value { get; set; }

        /// <summary>
        /// ファイルのパスを表現
        /// </summary>
        public required string Path { get; set; }

        /// <summary>
        /// ファイルが存在しているかを表す
        /// </summary>
        public bool Exist { get; set; } = true;

        /// <summary>
        /// ファイルの読み取りを表現
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <returns>ファイルの中身</returns>
        public string GetData(string file) => Value;

        /// <summary>
        /// ファイルの書き出しを表現
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">書き出す内容</param>
        public void SetData(string file, string value) => Value = value;

        /// <summary>
        /// ファイルの名前(path)の変更を表現
        /// </summary>
        /// <param name="file">名前を変えたいファイルの名前</param>
        /// <param name="newName">新しい名前</param>
        public void Rename(string file, string newName) => Path = newName;

        /// <summary>
        /// ファイルの削除を表現
        /// </summary>
        /// <param name="file">削除するファイル</param>
        public void Delete(string file)
        {
            Exist = false;
        }

    }
}
