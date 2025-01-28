// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// �e�X�g�p�̃��b�N�B�t�@�C��������ԐړI�ɕ\��
    /// </summary>
    public class TextFileMock : ITextFile
    {
        /// <summary>
        /// �t�@�C����\������Mock
        /// </summary>
        public class Mock(string value)
        {
            /// <summary>
            /// �t�@�C���̒��g��\������
            /// </summary>
            public string Value { get; set; } = value;

            /// <summary>
            /// �t�@�C�����ǂݎ���p������
            /// </summary>
            public bool ReadOnly { get; set; } = false;
        }

        /// <summary>
        /// �t�@�C����\���Bkey�̓t�@�C���̃p�X�Avalue�̓t�@�C���̒��g
        /// </summary>
        public Dictionary<string, Mock> FileDictionary { get; set; } = [];


        /// <summary>
        /// �t�@�C���̓ǂݎ���\��
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <returns>�t�@�C���̒��g</returns>
        public string GetData(string file) => FileDictionary[file].Value;

        /// <summary>
        /// �t�@�C���̏����o����\��
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="value">�����o�����e</param>
        public void SetData(string file, string value) {
            FileDictionary[file].Value = value;
        }

        /// <summary>
        /// �t�@�C���̐�����\��
        /// </summary>
        /// <param name="file"></param>
        /// <param name="value"></param>
        public void Create(string file,string value)
        {
            FileDictionary.Add(file, new(value));
            
        }

        /// <summary>
        /// �t�@�C���̖��O(path)�̕ύX��\��
        /// </summary>
        /// <param name="file">���O��ς������t�@�C���̖��O</param>
        /// <param name="newFile">�V�������O</param>
        public void Rename(string file, string newFile)
        {
            string value = FileDictionary[file].Value;
            FileDictionary.Remove(file);
            FileDictionary.Add(newFile, new(value));
        }

        /// <summary>
        /// �t�@�C���̍폜��\��
        /// </summary>
        /// <param name="file">�폜����t�@�C��</param>
        public void Delete(string file)
        {
            FileDictionary.Remove(file); 
        }

        /// <summary>
        /// �t�@�C���̃R�s�[��\��
        /// </summary>
        /// <param name="file">�R�s�[����t�@�C��</param>
        /// <param name="newFile">�R�s�[��̃t�@�C��</param>
        public void Copy(string file, string newFile)
        {
            string value = FileDictionary[file].Value;
            FileDictionary.Add(newFile, new(value));
        }

        /// <summary>
        /// �t�@�C���ɓǂݎ���p������ǉ�����
        /// </summary>
        /// <param name="file"></param>
        public void SetReadOnly(string file)
        {
            FileDictionary[file].ReadOnly = true;
        }

        /// <summary>
        /// �t�@�C���̓ǂݎ���p�������폜����
        /// </summary>
        /// <param name="file"></param>
        public void DeleteReadOnly(string file)
        {
            FileDictionary[file].ReadOnly = false;
        }

        /// <summary>
        /// �w�肵���t�@�C�������݂��Ă��邩�ǂ������ׂ�
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool Exists(string file)
        {
            return FileDictionary.ContainsKey(file);
        }
    }
}

