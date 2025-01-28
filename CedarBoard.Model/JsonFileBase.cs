// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json;
namespace CedarBoard.Model
{
    /// <summary>
    /// Json������ƃI�u�W�F�N�g�̑��ݕϊ����s�����ۃN���X
    /// </summary>
    public abstract class JsonFileBase
    {
        /// <summary>
        /// ���͂��ꂽ�I�u�W�F�N�g��Json������ɕϊ�����
        /// </summary>
        /// <param name="poco">Json������ɂ������I�u�W�F�N�g</param>
        /// <returns>Json������</returns>
        public static string Serialize(object poco)
        {
            var json = JsonSerializer.Serialize(poco, GetOptions());
            return json;
        }

        /// <summary>
        /// ���ꂽJson�������Object�ɕϊ�����
        /// </summary>
        /// <param name="json">�I�u�W�F�N�g�ɕς�����Json������</param>
        /// <returns>�I�u�W�F�N�g</returns>
        protected abstract object Deserialize(string json);

        /// <summary>
        /// ���g�̃I�u�W�F�N�g���w�肳�ꂽJson�t�@�C���ɃV���A���C�Y���ď�������
        /// </summary>
        public abstract void Save();


        /// <summary>
        /// �I�v�V������ݒ肷��B�������]�b�g
        /// </summary>
        /// <returns>�I�v�V�����ݒ�</returns>
        public static JsonSerializerOptions GetOptions()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            };
            return options;
        }
    }
}

