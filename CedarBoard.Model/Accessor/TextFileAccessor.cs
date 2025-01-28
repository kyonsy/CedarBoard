// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
namespace CedarBoard.Model.Accessor
{
    /// <summary>
    /// �{�Ԃ̃v���O�����Ŏg���A�t�@�C���ւ̃A�N�Z�T
    /// </summary>
    public class TextFileAccessor : ITextFile
    {
        /// <summary>
        /// �t�@�C���̓ǂݎ��
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <returns>�ǂݎ�������e</returns>
        public string GetData(string file)
        {
            return File.ReadAllText(file);
        }

        /// <summary>
        /// �t�@�C���̏����o��
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="value">�����o�����e</param>
        public void SetData(string file, string value)
        {
            if (!File.Exists(file)) throw new IOException("���̃��]�b�g�ł͐V�������O�̃t�@�C���𐶐����邱�Ƃ͏o���܂���");
            File.WriteAllText(file, value);
        }

        /// <summary>
        /// �t�@�C���̐���
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="value">��������t�@�C���̓��e</param>
        public void Create(string file, string value)
        {
            if (File.Exists(file)) throw new IOException("���̃��]�b�g�ł͊����̃t�@�C�����㏑�����邱�Ƃ͏o���܂���");
            File.WriteAllText(file, value);
        }

        /// <summary>
        /// �t�@�C���̖��O(path)��ς���
        /// </summary>
        /// <param name="file">�t�@�C���̃p�X</param>
        /// <param name="newFile">�V�������O(path)</param>
        public void Rename(string file, string newFile)
        {
            File.Move(file, newFile);
        }

        /// <summary>
        /// �t�@�C�����폜����
        /// </summary>
        /// <param name="file">�폜�������t�@�C��</param>
        public void Delete(string file)
        {
            File.Delete(file);
        }

        /// <summary>
        /// �t�@�C�����R�s�[����
        /// </summary>
        /// <param name="file">�R�s�[����t�@�C��</param>
        /// <param name="newFile">�R�s�[��̃t�@�C��</param>
        public void Copy(string file, string newFile)
        {
            File.Copy(file, newFile);
        }

        /// <summary>
        /// �w�肵���t�@�C���ɓǂݎ���p������ǉ�����
        /// </summary>
        /// <param name="file"></param>
        public void SetReadOnly(string file)
        {
            FileAttributes attr = File.GetAttributes(file);
            File.SetAttributes(file, attr | FileAttributes.ReadOnly);
        }

        /// <summary>
        /// �w�肵���t�@�C���̓ǂݎ���p�������폜����
        /// </summary>
        /// <param name="file"></param>
        public void DeleteReadOnly(string file)
        {
            FileAttributes attr = File.GetAttributes(file);
            File.SetAttributes(file, attr & ~(FileAttributes.ReadOnly));
        }

        /// <summary>
        /// �w�肵���t�@�C�������݂��Ă��邩���ׂ�
        /// </summary>
        /// <param name="file"></param>
        public bool Exists(string file)
        {
            return File.Exists(file);
        }
    }
}

