using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// 座標の情報を持っているPOCO
    /// </summary>
    public class PointPoco
    {
        /// <summary>
        /// X成分
        /// </summary>
        [JsonPropertyName("x")]
        public required int X { get; set; }

        /// <summary>
        /// Y成分
        /// </summary>
        [JsonPropertyName("y")]
        public required int Y { get; set; }
    }
}
