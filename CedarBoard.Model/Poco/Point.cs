using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// ノードの座標
    /// </summary>
    public class Point
    {
        /// <summary>
        /// ノードのX座標
        /// </summary>
        [JsonPropertyName("x")]
        public int X { get; set; }

        /// <summary>
        /// ノードのY座標
        /// </summary>
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
