// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// ���ۂ̃A�v���P�[�V�����Ŏg���f�B���N�g���̃A�N�Z�T
    /// </summary>
    public class DirectoryAccessor : IDirectory
    {
        /// <summary>
        /// �f�B���N�g�����쐬
        /// </summary>
        /// <param name="path">���f�B���N�g���̃p�X</param>
        public void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// �f�B���N�g���̍폜
        /// </summary>
        /// <param name="path">�폜�������f�B���N�g���̃p�X</param>
        public void Delete(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }           
        }

        /// <summary>
        /// �f�B���N�g���̈��k
        /// </summary>
        /// <param name="path">���k����f�B���N�g���̃p�X</param>
        public void Compress(string path)
        {
            throw new NotImplementedException("���x�܂�����");
        }

        /// <summary>
        /// �f�B���N�g���̉�
        /// </summary>
        /// <param name="path">�𓚂���f�B���N�g���̃p�X</param>
        public void Unfreeze(string path)
        {
            throw new NotImplementedException("���x�܂�����");
        }

        /// <summary>
        ///  ����f�B�N�V���i�������ɑ��݂��Ă��邩�m�F����
        /// </summary>
        /// <param name="dictionary">���݂��m�F����f�B���N�g���̃p�X</param>
        /// <returns>����̂��ǂ�����Ԃ�</returns>
        public bool Exists(string dictionary)
        {
            return Directory.Exists(dictionary);
        }
    }
}

