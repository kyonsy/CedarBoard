using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// workspace.jsonからの文字列をデシリアライズするためのPOCO
    /// </summary>
    public record WorkspacePoco
    {
        ///<summary>
        /// 設定
        ///</summary>
        [JsonInclude]
        public required Setting Setting { get; set; }

        /// <summary>
        /// プロジェクトの名前のディクショナリ。keyはディレクトリの名前、valueはそのオブジェクト
        /// </summary>
        [JsonInclude]
        public required Dictionary<string, Project> ProjectDictionary { get; set; } = [];
    }
}
