// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// �f�B���N�g����\�����邽�߂̃C���^�[�t�F�C�X
    /// </summary>
    public interface IDirectory
    {
        /// <summary>
        /// �f�B���N�g�����폜����
        /// </summary>
        public void Delete(string path);

        /// <summary>
        /// �f�B���N�g�����쐬����
        /// </summary>
        /// <param name="path"></param>
        public void Create(string path);

        /// <summary>
        /// �f�B���N�g�������k����
        /// </summary>
        /// <param name="path"></param>
        public void Compress(string path);

        /// <summary>
        /// �f�B���N�g�����𓀂���
        /// </summary>
        /// <param name="path"></param>
        public void Unfreeze(string path);

        /// <summary>
        /// ����p�X�̃f�B���N�g�������邩�ǂ������ׂ�
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public bool Exists(string directory);
    }
}

