using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 設定の情報を持っているPOCO
    /// </summary>
    public sealed class SettingPoco
    {
        /// <summary>
        /// 使うフォーマット
        /// </summary>
        [JsonPropertyName("format")]
        public required string Format { get; set; }

        /// <summary>
        /// 使うエディター
        /// </summary>
        [JsonPropertyName("editor")]
        public required string Editor { get; set; }

        /// <summary>
        /// 使うエンコード
        /// </summary>
        [JsonPropertyName("encode")]
        public required string Encode { get; set; }

        /// <summary>
        /// 使用する言語
        /// </summary>
        [JsonPropertyName("languege")]
        public required string Language { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonPropertyName("auther")]
        public required string Author { get; set; }

        /// <summary>
        /// ワークスペースの名前
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        [JsonPropertyName("createdDate")]
        public required string CreatedDate { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        [JsonPropertyName("updatedDate")]
        public required string UpdatedDate { get; set; }

        /// <summary>
        /// ワークスペースのパス
        /// </summary>
        [JsonPropertyName("path")]
        public required string Path { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        [JsonPropertyName("message")]
        public required string Message { get; set; }
        
    }
}
