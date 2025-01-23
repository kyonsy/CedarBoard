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
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public Point(int x,int y) => (X,Y) = (x,y); 
    }
}
