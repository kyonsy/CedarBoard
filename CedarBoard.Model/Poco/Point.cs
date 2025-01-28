// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// �m�[�h�̍��W
    /// </summary>
    public record Point
    {
        /// <summary>
        /// �m�[�h��X���W
        /// </summary>
        [JsonInclude]
        public double X { get; set; }

        /// <summary>
        /// �m�[�h��Y���W
        /// </summary>
        [JsonInclude]
        public double Y { get; set; }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="x">X���W</param>
        /// <param name="y">Y���W</param>
        public Point(double x, double y) => (X, Y) = (x, y);
    }
}

