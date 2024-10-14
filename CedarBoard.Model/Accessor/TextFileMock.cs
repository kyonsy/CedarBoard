using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
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

    }
}
