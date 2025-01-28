// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// �e�X�g�p�ɍ�����t�@�C������̃C���^�[�t�F�C�X
    /// </summary>
    public interface ITextFile
    {
        /// <summary>
        /// �t�@�C���̓ǂݎ��
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <returns>�ǂݎ�������e</returns>
        public string GetData(string file);

        /// <summary>
        /// �t�@�C���̏����o��
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="value">�����o�����e</param>
        public void SetData(string file, string value);

        /// <summary>
        /// �t�@�C���̐���
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="value">��������t�@�C���̓��e</param>
        public void Create(string file, string value);


        /// <summary>
        /// �t�@�C���̖��O(path)�̕ύX
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="newFile">�V�������O</param>
        public void Rename(string file, string newFile);

        /// <summary>
        /// �t�@�C���̍폜
        /// </summary>
        /// <param name="file">�폜���������O</param>
        public void Delete(string file);

        /// <summary>
        /// �t�@�C���̃R�s�[
        /// </summary>
        /// <param name="file">�R�s�[����t�@�C��</param>
        /// <param name="newFile">�R�s�[��̃t�@�C��</param>
        public void Copy(string file, string newFile);

        /// <summary>
        /// �w�肵���t�@�C���ɓǂݎ���p������ǉ�����
        /// </summary>
        public void SetReadOnly(string file);

        /// <summary>
        /// �w�肵���t�@�C���̓ǂݎ���p�������폜����
        /// </summary>
        /// <param name="file"></param>
        public void DeleteReadOnly(string file);

        /// <summary>
        /// �w�肵���t�@�C�������݂��Ă��邩���ׂ�
        /// </summary>
        /// <param name="file"></param>
        public bool Exists(string file);
    }
}

