using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model
{
    internal sealed class Setting
    {
        /// <summary>
        /// 描画のフォーマット(複数作りたい)
        /// </summary>
        public string Format {  get; set; }

        /// <summary>
        /// 使うテキストエディタの絶対パス
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// 使うエンコード
        /// </summary>
        public string Encode {  get; set; }

        /// <summary>
        /// 使用言語
        /// </summary>
        public string Language {  get; set; }

        /// <summary>
        /// 著者名
        /// </summary>
        public string Author {  get; set; }

        /// <summary>
        /// ワークスペース名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public string CreatedDate {  get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public string UpdatedDate {  get; set; }

        /// <summary>
        /// メッセージ(ワークスペースの解説)
        /// </summary>
        public string Message {  get; set; }
    }
}
