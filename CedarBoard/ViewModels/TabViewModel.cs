// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
namespace CedarBoard.ViewModels
{
    /// <summary>
    /// タブのビューモデル
    /// </summary>
    public record TabViewModel
    {
        /// <summary>
        /// ヘッダーエリア
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// DataContextに入れるViewModel
        /// </summary>
        public ProjectUserControlViewModel ProjectViewModel { get; set; }
    }
}

