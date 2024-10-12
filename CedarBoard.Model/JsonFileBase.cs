using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace CedarBoard.Model
{
    /// <summary>
    /// Json文字列とオブジェクトの相互変換を行う抽象クラス
    /// </summary>
    public abstract class JsonFileBase
    {
        /// <summary>
        /// 入力されたオブジェクトをJson文字列に変換する
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        protected string? Serialize(object poco)
        {
            try
            {
                var json = JsonSerializer.Serialize(poco, GetOptions());
                return json;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 入力されたJson文字列をオブジェクトに変更する
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        protected object? Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json)) return null;
            try
            {
                object? poco = JsonSerializer.Deserialize<object>(json, GetOptions());
                return poco;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// オプションを設定する。内部メゾット
        /// </summary>
        /// <returns></returns>
        private JsonSerializerOptions GetOptions()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            return options;
        }
    }
}
