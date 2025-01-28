// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Collections.Generic;

namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// �f�B���N�g����\������Mock
    /// </summary>
    public class DirectoryMock : IDirectory
    {
        /// <summary>
        /// �f�B���N�g���̓����\��
        /// </summary>
        public class Mock()
        {
            /// <summary>
            /// �f�B���N�g�������k����Ă��邩����
            /// </summary>
            public bool Compressed { get; set; } = false;
        }

        /// <summary>
        /// �f�B���N�g���̏W�������z�I�ɍČ�
        /// </summary>
        public Dictionary<string,Mock> DirectoryDictionary { get; set; } = [];

        /// <summary>
        /// �f�B���N�g���̐��������z�I�ɕ\��
        /// </summary>
        /// <param name="path">��������f�B���N�g���̃p�X</param>
        public void Create(string path)
        {
            DirectoryDictionary.Add(path,new());
        }

        /// <summary>
        /// �f�B���N�g���̍폜�����z�I�ɕ\��
        /// </summary>
        /// <param name="path">�폜�������f�B���N�g���̃p�X</param>
        public void Delete(string path)
        {
            DirectoryDictionary.Remove(path);
        }

        /// <summary>
        /// �f�B���N�g���̈��k��\��
        /// </summary>
        /// <param name="path"></param>
        public void Compress(string path)
        {
            DirectoryDictionary[path].Compressed = true;
        }

        /// <summary>
        /// �f�B���N�g���̉𓀂�\��
        /// </summary>
        /// <param name="path"></param>
        public void Unfreeze(string path)
        {
            DirectoryDictionary[path].Compressed = false;
        }

        /// <summary>
        /// ����f�B�N�V���i�������邩�ǂ������ׂ�
        /// </summary>
        /// <param name="direcory"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Exists(string direcory)
        {
            return DirectoryDictionary.ContainsKey(direcory);
        }
    }
}

