using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Objects
{
    public sealed class Setting
    {
        /// <summary>
        /// 描画のフォーマット(複数作りたい)
        /// </summary>
        public required string Format { get; set; }

        /// <summary>
        /// 使うテキストエディタの絶対パス
        /// </summary>
        public required string Editor { get; set; }

        /// <summary>
        /// 使うエンコード
        /// </summary>
        public required string Encode { get; set; }

        /// <summary>
        /// 使用言語
        /// </summary>
        public required string Language { get; set; }

        /// <summary>
        /// 著者名
        /// </summary>
        public required string Author { get; set; }

        /// <summary>
        /// ワークスペース名
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public required string CreatedDate { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public required string UpdatedDate { get; set; }

        /// <summary>
        /// メッセージ(ワークスペースの解説)
        /// </summary>
        public required string Message { get; set; }

    }
}
