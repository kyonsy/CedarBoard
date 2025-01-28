// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Text.Json.Serialization;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// �m�[�h�̃C���^�[�t�F�C�X
    /// </summary>
    [JsonDerivedType(typeof(Node),nameof(Node))]
    [JsonDerivedType(typeof(OriginNode),nameof(OriginNode))]
    public interface INode
    {
        /// <summary>
        /// �m�[�h�̃p�X
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// �m�[�h�̍��W
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// �q�m�[�h�̖��O
        /// </summary>
        public List<string> ChildNode { get; set; }

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// �쐬����
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// �m�[�h�̖��O
        /// </summary>
        public string Name {  get; set; }
    }
}

