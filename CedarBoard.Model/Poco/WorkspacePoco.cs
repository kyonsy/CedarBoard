using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// workspace.jsonからの文字列をデシリアライズするためのPOCO
    /// </summary>
    public class WorkspacePoco
    {
        ///<summary>
        /// 設定
        /// </summary>
        [JsonPropertyName("setting")]
        public required Setting Setting { get; set; }

        /// <summary>
        /// プロジェクトの名前のディクショナリ。keyはディレクトリの名前、valueはそのパス
        /// </summary>
        [JsonPropertyName("project")]
        public Dictionary<string, Project> ProjectDictionary { get; set; } = [];
    }
}
