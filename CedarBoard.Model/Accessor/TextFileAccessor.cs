namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// 本番のプログラムで使う、ファイルへのアクセサ
    /// </summary>
    public class TextFileAccessor : ITextFile
    {
        /// <summary>
        /// ファイルの読み取り
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <returns>読み取った内容</returns>
        public string GetData(string file)
        {
            return File.ReadAllText(file);
        }

        /// <summary>
        /// ファイルの書き出し
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">書き出す内容</param>
        public void SetData(string file, string value)
        {
            File.WriteAllText(file, value);
        }
    }
}
