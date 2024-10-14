using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
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
    }
}
