// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// workspace.json����̕�������f�V���A���C�Y���邽�߂�POCO
    /// </summary>
    public record WorkspacePoco
    {
        ///<summary>
        /// �ݒ�
        ///</summary>
        [JsonInclude]
        public required Setting Setting { get; set; }

        /// <summary>
        /// �v���W�F�N�g�̖��O�̃f�B�N�V���i���Bkey�̓f�B���N�g���̖��O�Avalue�͂��̃I�u�W�F�N�g
        /// </summary>
        [JsonInclude]
        public required Dictionary<string, Project> ProjectDictionary { get; set; } = [];
    }
}

