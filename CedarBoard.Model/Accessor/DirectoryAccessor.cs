namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// 実際のアプリケーションで使うディレクトリのアクセサ
    /// </summary>
    public class DirectoryAccessor : IDirectory
    {
        /// <summary>
        /// ディレクトリを作成
        /// </summary>
        /// <param name="path">作るディレクトリのパス</param>
        public void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// ディレクトリの削除
        /// </summary>
        /// <param name="path">削除したいディレクトリのパス</param>
        public void Delete(string path)
        {
            Directory.Delete(path, true);
        }
    }
}
