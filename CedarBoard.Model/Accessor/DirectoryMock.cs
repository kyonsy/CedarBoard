namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// ディレクトリを表現するMock
    /// </summary>
    public class DirectoryMock : IDirectory
    {
        /// <summary>
        /// ディレクトリの集合を仮想的に再現
        /// </summary>
        public HashSet<string> DirectorySet { get; set; } = [];

        /// <summary>
        /// ディレクトリの生成を仮想的に表現
        /// </summary>
        /// <param name="path">生成するディレクトリのパス</param>
        public void Create(string path)
        {
            DirectorySet.Add(path);
        }

        /// <summary>
        /// ディレクトリの削除を仮想的に表現
        /// </summary>
        /// <param name="path">削除したいディレクトリのパス</param>
        public void Delete(string path)
        {
            DirectorySet.Remove(path);
        }
    }
}
