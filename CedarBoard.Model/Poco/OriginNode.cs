// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// �ŏ��ɐ��������m�[�h
    /// </summary>
    public sealed record OriginNode : INode
    {
        /// <summary>
        /// �m�[�h�̃p�X
        /// </summary>
        [JsonInclude]
        public required string Path { get; set; }


        /// <summary>
        /// �m�[�h�̍��W
        /// </summary>
        [JsonInclude]
        public required Point Point { get; set; }

        /// <summary>
        /// �q�m�[�h�̖��O
        /// </summary>
        [JsonInclude]
        public required List<string> ChildNode { get; set; }


        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        [JsonInclude]
        public required string Message { get; set; }


        /// <summary>
        /// �쐬����
        /// </summary>
        [JsonInclude]
        public required DateTime Data { get; set; }

        /// <summary>
        /// �m�[�h�̖��O
        /// </summary>
        [JsonInclude]
        public required string Name { get; set; }
    }
}

