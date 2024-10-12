using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    public sealed class Selector : JsonFileBase
    {
        [JsonPropertyName("pathList")]
        public List<string>? PathList { get; set; }


        /// <summary>
        /// 新しいワークスペースを追加して返す
        /// </summary>
        /// <param name="path"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public WorkSpace Add(string path, SettingPoco setting)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="path"></param>
        public void Remove(string path)
        {
        }

        /// <summary>
        /// 指定されたワークスペースを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public WorkSpace GetWorkSpace(string path)
        {
            throw new NotImplementedException();
        }
    }
}
