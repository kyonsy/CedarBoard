// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// �Z���N�^�̏��������Ă���POCI
    /// </summary>
    public record SelectorPoco
    {
        /// <summary>
        /// ���[�N�X�y�[�X�̖��O���L�[�ɁA���̃p�X��ێ�����
        /// </summary>
        public required Dictionary<string, string> PathDictionary { get; set; } = [];
    }
}

