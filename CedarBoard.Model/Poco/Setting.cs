// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 設定の情報を持っているPOCO
    /// </summary>
    public record Setting
    {
        /// <summary>
        /// 使うフォーマット
        /// </summary>
        [JsonInclude]
        public required string Format { get; set; }

        /// <summary>
        /// 使うエディター
        /// </summary>
        [JsonInclude]
        public required string Editor { get; set; }

        /// <summary>
        /// 使うエンコード
        /// </summary>
        [JsonInclude]
        public required string Encode { get; set; }

        /// <summary>
        /// 使用する言語
        /// </summary>
        [JsonInclude]
        public required string Language { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonInclude]
        public required string Author { get; set; }

        /// <summary>
        /// ワークスペースの名前
        /// </summary>
        [JsonInclude]
        public required string Name { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        [JsonInclude]
        public required string CreatedDate { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        [JsonInclude]
        public required string UpdatedDate { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        [JsonInclude]
        public required string Message { get; set; }

    }
}

