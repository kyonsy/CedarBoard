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
            if (!File.Exists(file)) throw new IOException("このメゾットでは新しい名前のファイルを生成することは出来ません");
            File.WriteAllText(file, value);
        }

        /// <summary>
        /// ファイルの生成
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">生成するファイルの内容</param>
        public void Create(string file, string value)
        {
            if (File.Exists(file)) throw new IOException("このメゾットでは既存のファイルを上書きすることは出来ません");
            File.WriteAllText(file, value);
        }

        /// <summary>
        /// ファイルの名前(path)を変える
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="newFile">新しい名前(path)</param>
        public void Rename(string file, string newFile) {
            File.Move(file, newFile);
        }

        /// <summary>
        /// ファイルを削除する
        /// </summary>
        /// <param name="file">削除したいファイル</param>
        public void Delete(string file) { 
            File.Delete(file);
        }

        /// <summary>
        /// ファイルをコピーする
        /// </summary>
        /// <param name="file">コピーするファイル</param>
        /// <param name="newFile">コピー先のファイル</param>
        public void Copy(string file, string newFile)
        {
            File.Copy(file, newFile);
        }

        /// <summary>
        /// 指定したファイルに読み取り専用属性を追加する
        /// </summary>
        /// <param name="file"></param>
        public void SetReadOnly(string file) { 
            FileAttributes attr = File.GetAttributes(file);
            File.SetAttributes(file, attr | FileAttributes.ReadOnly);
        }

        /// <summary>
        /// 指定したファイルの読み取り専用属性を削除する
        /// </summary>
        /// <param name="file"></param>
        public void DeleteReadOnly(string file) {
            FileAttributes attr = File.GetAttributes(file);
            File.SetAttributes(file, attr & ~(FileAttributes.ReadOnly));
        }
    }
}
