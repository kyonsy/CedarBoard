// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
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
        public double X { get; set; }

        /// <summary>
        /// ノードのY座標
        /// </summary>
        [JsonInclude]
        public double Y { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public Point(double x, double y) => (X, Y) = (x, y);
    }
}

