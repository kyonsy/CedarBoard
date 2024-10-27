using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// ノードの座標
    /// </summary>
    public record Point
    {
        /// <summary>
        /// ノードのX座標
        /// </summary>
        [JsonInclude]
        public int X { get; set; }

        /// <summary>
        /// ノードのY座標
        /// </summary>
        [JsonInclude]
        public int Y { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x,int y) => (X,Y) = (x,y); 
    }
}
