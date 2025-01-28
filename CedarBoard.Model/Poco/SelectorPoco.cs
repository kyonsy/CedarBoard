// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// セレクタの情報を持っているPOCI
    /// </summary>
    public record SelectorPoco
    {
        /// <summary>
        /// ワークスペースの名前をキーに、そのパスを保持する
        /// </summary>
        public required Dictionary<string, string> PathDictionary { get; set; } = [];
    }
}

