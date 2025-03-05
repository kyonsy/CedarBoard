// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
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
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }           
        }

        /// <summary>
        /// ディレクトリの圧縮
        /// </summary>
        /// <param name="path">圧縮するディレクトリのパス</param>
        public void Compress(string path)
        {
            throw new NotImplementedException("今度また作るわ");
        }

        /// <summary>
        /// ディレクトリの解凍
        /// </summary>
        /// <param name="path">解答するディレクトリのパス</param>
        public void Unfreeze(string path)
        {
            throw new NotImplementedException("今度また作るわ");
        }

        /// <summary>
        ///  あるディクショナリが既に存在しているか確認する
        /// </summary>
        /// <param name="dictionary">存在を確認するディレクトリのパス</param>
        /// <returns>あるのかどうかを返す</returns>
        public bool Exists(string dictionary)
        {
            return Directory.Exists(dictionary);
        }
    }
}

