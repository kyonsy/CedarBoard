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
        /// <param name="poco">Json文字列にしたいオブジェクト</param>
        /// <returns>Json文字列</returns>
        public static string Serialize(object poco)
        {
            var json = JsonSerializer.Serialize(poco, GetOptions());
            return json;
        }

        /// <summary>
        /// 入れたJson文字列をObjectに変換する
        /// </summary>
        /// <param name="json">オブジェクトに変えたいJson文字列</param>
        /// <returns>オブジェクト</returns>
        protected abstract object Deserialize(string json);

        /// <summary>
        /// 自身のオブジェクトを指定されたJsonファイルにシリアライズして書き込む
        /// </summary>
        public abstract void Save();


        /// <summary>
        /// オプションを設定する。内部メゾット
        /// </summary>
        /// <returns>オプション設定</returns>
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
