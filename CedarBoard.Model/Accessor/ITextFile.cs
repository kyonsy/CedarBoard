namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// テスト用に作ったファイル操作のインターフェイス
    /// </summary>
    public interface ITextFile
    {
        /// <summary>
        /// ファイルの読み取り
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <returns>読み取った内容</returns>
        public string GetData(string file);

        /// <summary>
        /// ファイルの書き出し
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">書き出す内容</param>
        public void SetData(string file, string value);

        /// <summary>
        /// ファイルの生成
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="value">生成するファイルの内容</param>
        public void Create(string file,string value);


        /// <summary>
        /// ファイルの名前(path)の変更
        /// </summary>
        /// <param name="file">ファイルのパス</param>
        /// <param name="newFile">新しい名前</param>
        public void Rename(string file, string newFile);

        /// <summary>
        /// ファイルの削除
        /// </summary>
        /// <param name="file">削除したい名前</param>
        public void Delete(string file);

        /// <summary>
        /// ファイルのコピー
        /// </summary>
        /// <param name="file">コピーするファイル</param>
        /// <param name="newFile">コピー先のファイル</param>
        public void Copy(string file,string newFile);

        /// <summary>
        /// 指定したファイルに読み取り専用属性を追加する
        /// </summary>
        public void SetReadOnly(string file);

        /// <summary>
        /// 指定したファイルの読み取り専用属性を削除する
        /// </summary>
        /// <param name="file"></param>
        public void DeleteReadOnly(string file);
    }
}
