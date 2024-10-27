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

        /// <summary>
        /// ディレクトリを圧縮する
        /// </summary>
        /// <param name="path"></param>
        public void Compress(string path);

        /// <summary>
        /// ディレクトリを解凍する
        /// </summary>
        /// <param name="path"></param>
        public void Unfreeze(string path);

        /// <summary>
        /// あるパスのディレクトリがあるかどうか調べる
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public bool CheckDirectory(string directory);
    }
}
