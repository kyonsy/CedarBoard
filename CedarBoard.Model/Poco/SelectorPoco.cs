using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Poco
{
    /// <summary>
    /// セレクタの情報を持っているPOCI
    /// </summary>
    public record SelectorPoco
    {
        /// <summary>
        /// ワークスペースの名前をキーに、そのパスを保持する
        /// </summary>
        public required Dictionary<string, string> PathDictionary { get; set; } = [];
    }

}
