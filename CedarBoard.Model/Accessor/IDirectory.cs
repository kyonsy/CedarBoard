namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// ディレクトリを表現するためのインターフェイス
    /// </summary>
    public interface IDirectory
    {
        /// <summary>
        /// ディレクトリを削除する
        /// </summary>
        public void Delete(string path);

        /// <summary>
        /// ディレクトリを作成する
        /// </summary>
        /// <param name="path"></param>
        public void Create(string path);
    }
}
