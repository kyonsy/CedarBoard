using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json.Serialization;

namespace CedarBoard.Model
{
    public sealed class WorkSpace : JsonFileBase
    {
        private ITextFile _textFile;

        public WorkSpace(ITextFile textFile)
        {
            _textFile = textFile;
        }

        [JsonPropertyName("path")]
        public required string Path { get; set; }

        [JsonPropertyName("setting")]
        public required SettingPoco Setting { get; set; }

        [JsonPropertyName("projectList")]
        public List<string>? ProjectList { get; set; }


        /// <summary>
        /// 新しいプログラムを追加して返す
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Project Add(string project)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定されたプロジェクトを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index) { }

        /// <summary>
        /// 指定されたプロジェクトを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Project GetProject(int index)
        {
            throw new NotImplementedException();
        }
    }
}
