// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// �ݒ�̏��������Ă���POCO
    /// </summary>
    public record Setting
    {
        /// <summary>
        /// �g���t�H�[�}�b�g
        /// </summary>
        [JsonInclude]
        public required string Format { get; set; }

        /// <summary>
        /// �g���G�f�B�^�[
        /// </summary>
        [JsonInclude]
        public required string Editor { get; set; }

        /// <summary>
        /// �g���G���R�[�h
        /// </summary>
        [JsonInclude]
        public required string Encode { get; set; }

        /// <summary>
        /// �g�p���錾��
        /// </summary>
        [JsonInclude]
        public required string Language { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [JsonInclude]
        public required string Author { get; set; }

        /// <summary>
        /// ���[�N�X�y�[�X�̖��O
        /// </summary>
        [JsonInclude]
        public required string Name { get; set; }

        /// <summary>
        /// �쐬����
        /// </summary>
        [JsonInclude]
        public required string CreatedDate { get; set; }

        /// <summary>
        /// �X�V����
        /// </summary>
        [JsonInclude]
        public required string UpdatedDate { get; set; }

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        [JsonInclude]
        public required string Message { get; set; }

    }
}

